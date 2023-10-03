using System.Globalization;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml;
using Bazunov_Components.Models;
using static System.String;
using Index = DocumentFormat.OpenXml.Drawing.Charts.Index;
using Orientation = DocumentFormat.OpenXml.Drawing.Charts.Orientation;

namespace Bazunov_Components.Helpers;

public static class ChartGenerator
{
    private static uint _order;

    private static uint _index = 1u;

    public static DocumentFormat.OpenXml.Drawing.Charts.Chart GenerateBarChart(ChartConfig config)
    {
        var axisId = new AxisId {
            Val = (UInt32Value)97045504u
        };
        var axisId2 = new AxisId {
            Val = (UInt32Value)97055488u
        };
        var barChart = new BarChart();
        barChart.Append(new BarDirection {
            Val = (EnumValue<BarDirectionValues>)BarDirectionValues.Column
        });
        barChart.Append(new BarGrouping {
            Val = (EnumValue<BarGroupingValues>)BarGroupingValues.Clustered
        });
        if (config.Data != null)
            barChart.Append(
                GenerateBarChartSeries(config.Data.First().Key, config.Data.First().Value));
        barChart.Append(axisId);
        barChart.Append(axisId2);
        var outline = new Outline {
            Width = (Int32Value)25400
        };
        outline.Append(new NoFill());
        var shapeProperties = new DocumentFormat.OpenXml.Drawing.Charts.ShapeProperties();
        shapeProperties.Append(new NoFill());
        shapeProperties.Append(outline);
        var plotArea = new PlotArea();
        plotArea.Append(new Layout());
        plotArea.Append(barChart);
        plotArea.Append(GenerateCategoryAxis(axisId, AxisPositionValues.Bottom, axisId2));
        plotArea.Append(GenerateValueAxis(axisId2, AxisPositionValues.Left, axisId));
        plotArea.Append(shapeProperties);
        return GenerateChart(config.ChartTitle, plotArea, config.LegendLocation);
    }

    private static DocumentFormat.OpenXml.Drawing.Charts.Chart GenerateChart(
        string titleText, 
        OpenXmlElement plotArea, 
        Location legendLocation)
    {
        var chart = new DocumentFormat.OpenXml.Drawing.Charts.Chart();
        if (IsNullOrWhiteSpace(titleText))
        {
            chart.Append(GenerateTitle(titleText));
        }
        else
        {
            chart.Append(new AutoTitleDeleted
            {
                Val = (BooleanValue)true
            });
        }

        var position = legendLocation switch
        {
            Location.Top => LegendPositionValues.Top,
            Location.Right => LegendPositionValues.Right,
            Location.Left => LegendPositionValues.Left,
            _ => LegendPositionValues.Bottom,
        };
        chart.Append(plotArea);
        chart.Append(GenerateLegend(position));
        chart.Append(new PlotVisibleOnly
        {
            Val = (BooleanValue)true
        });
        return chart;
    }

    private static Title GenerateTitle(string titleText)
    {
        var run = new Run();
        run.Append(new RunProperties {
            FontSize = (Int32Value)1100
        });
        run.Append(new Text(titleText));
        var paragraphProperties = new ParagraphProperties();
        paragraphProperties.Append(new DefaultRunProperties {
            FontSize = (Int32Value)1100
        });
        var paragraph = new Paragraph();
        paragraph.Append(paragraphProperties);
        paragraph.Append(run);
        var richText = new RichText();
        richText.Append(new BodyProperties());
        richText.Append(new ListStyle());
        richText.Append(paragraph);
        var chartText = new ChartText();
        chartText.Append(richText);
        var title = new Title();
        title.Append(chartText);
        title.Append(new Layout());
        title.Append(new Overlay {
            Val = (BooleanValue)false
        });
        return title;
    }

    private static BarChartSeries GenerateBarChartSeries(
        string seriesName, 
        IReadOnlyCollection<(int Date, double Value)> data)
    {
        var barChartSeries = new BarChartSeries();
        barChartSeries.Append(new Index {
            Val = (UInt32Value)_index
        });
        barChartSeries.Append(new Order {
            Val = (UInt32Value)_order
        });
        barChartSeries.Append(GenerateSeriesText(seriesName));
        barChartSeries.Append(GenerateCategoryAxisData(data.Select(c => c.Date.ToString()).ToArray()));
        barChartSeries.Append(GenerateValues(data.Select(v => v.Value).ToArray()));
        _index++; _order++;
        return barChartSeries;
    }

    private static SeriesText GenerateSeriesText(string seriesName)
    {
        var stringPoint = new StringPoint {
            Index = (UInt32Value)0u
        };
        stringPoint.Append(new NumericValue {
            Text = seriesName
        });
        var stringCache = new StringCache();
        stringCache.Append(new PointCount {
            Val = (UInt32Value)1u
        });
        stringCache.Append(stringPoint);
        var stringReference = new StringReference();
        stringReference.Append(stringCache);
        var seriesText = new SeriesText();
        seriesText.Append(stringReference);
        return seriesText;
    }

    private static CategoryAxisData GenerateCategoryAxisData(IReadOnlyList<string> data)
    {
        var num = (uint)data.Count;
        var numberingCache = GenerateNumberingCache(num);
        for (var num2 = 0u; num2 < num; num2++) {
            numberingCache.Append(GenerateNumericPoint(num2, data[(int)num2]));
        }

        var numberReference = new NumberReference();
        numberReference.Append(numberingCache);
        var categoryAxisData = new CategoryAxisData();
        categoryAxisData.Append(numberReference);
        return categoryAxisData;
    }

    private static Values GenerateValues(double[] data)
    {
        var num = (uint)data.Length;
        var numberingCache = GenerateNumberingCache(num);
        for (var num2 = 0u; num2 < num; num2++) {
            numberingCache.Append(GenerateNumericPoint(num2, data[num2]
                .ToString(CultureInfo.CurrentCulture)));
        }

        var numberReference = new NumberReference();
        numberReference.Append(numberingCache);
        var values = new Values();
        values.Append(numberReference);
        return values;
    }

    private static NumberingCache GenerateNumberingCache(uint numPoints)
    {
        var numberingCache = new NumberingCache();
        numberingCache.Append(new FormatCode {
            Text = "General"
        });
        numberingCache.Append(new PointCount {
            Val = (UInt32Value)numPoints
        });
        return numberingCache;
    }

    private static NumericPoint GenerateNumericPoint(UInt32Value idx, string text)
    {
        var numericPoint = new NumericPoint {
            Index = idx
        };
        numericPoint.Append(new NumericValue {
            Text = text
        });
        return numericPoint;
    }

    private static CategoryAxis GenerateCategoryAxis(
        UnsignedIntegerType axisId, 
        AxisPositionValues axisPosition, 
        UnsignedIntegerType crossingAxisId)
    {
        var scaling = new Scaling();
        scaling.Append(new Orientation {
            Val = (EnumValue<OrientationValues>)OrientationValues.MinMax
        });
        var solidFill = new SolidFill();
        solidFill.Append(new RgbColorModelHex {
            Val = (HexBinaryValue)"000000"
        });
        var defaultRunProperties = new DefaultRunProperties {
            FontSize = (Int32Value)1000,
            Bold = (BooleanValue)false,
            Italic = (BooleanValue)false,
            Underline = (EnumValue<TextUnderlineValues>)TextUnderlineValues.None,
            Strike = (EnumValue<TextStrikeValues>)TextStrikeValues.NoStrike,
            Baseline = (Int32Value)0
        };
        defaultRunProperties.Append(solidFill);
        var paragraphProperties = new ParagraphProperties();
        paragraphProperties.Append(defaultRunProperties);
        var paragraph = new Paragraph();
        paragraph.Append(paragraphProperties);
        paragraph.Append(new EndParagraphRunProperties());
        var textProperties = new TextProperties();
        textProperties.Append(new BodyProperties {
            Rotation = (Int32Value)(-1800000),
            Vertical = (EnumValue<TextVerticalValues>)TextVerticalValues.Horizontal
        });
        textProperties.Append(new ListStyle());
        textProperties.Append(paragraph);
        var categoryAxis = new CategoryAxis();
        categoryAxis.Append(new AxisId {
            Val = axisId.Val
        });
        categoryAxis.Append(scaling);
        categoryAxis.Append(new AxisPosition {
            Val = (EnumValue<AxisPositionValues>)axisPosition
        });
        categoryAxis.Append(new NumberingFormat {
            FormatCode = (StringValue)"General",
            SourceLinked = (BooleanValue)true
        });
        categoryAxis.Append(new TickLabelPosition {
            Val = (EnumValue<TickLabelPositionValues>)TickLabelPositionValues.Low
        });
        categoryAxis.Append(GenerateChartShapeProperties(3175));
        categoryAxis.Append(textProperties);
        categoryAxis.Append(new CrossingAxis {
            Val = crossingAxisId.Val
        });
        categoryAxis.Append(new Crosses {
            Val = (EnumValue<CrossesValues>)CrossesValues.AutoZero
        });
        categoryAxis.Append(new AutoLabeled {
            Val = (BooleanValue)true
        });
        categoryAxis.Append(new LabelAlignment {
            Val = (EnumValue<LabelAlignmentValues>)LabelAlignmentValues.Center
        });
        categoryAxis.Append(new LabelOffset {
            Val = (UInt16Value)(ushort)100
        });
        categoryAxis.Append(new TickLabelSkip {
            Val = (Int32Value)1
        });
        categoryAxis.Append(new TickMarkSkip {
            Val = (Int32Value)1
        });
        return categoryAxis;
    }

    private static ValueAxis GenerateValueAxis(
        UnsignedIntegerType axisId, 
        AxisPositionValues position, 
        UnsignedIntegerType crossingAxisId)
    {
        var scaling = new Scaling();
        scaling.Append(new Orientation {
            Val = (EnumValue<OrientationValues>)OrientationValues.MinMax
        });
        var paragraphProperties = new ParagraphProperties();
        paragraphProperties.Append(new DefaultRunProperties());
        var paragraph = new Paragraph();
        paragraph.Append(paragraphProperties);
        paragraph.Append(new EndParagraphRunProperties());
        var textProperties = new TextProperties();
        textProperties.Append(new BodyProperties());
        textProperties.Append(new ListStyle());
        textProperties.Append(paragraph);
        var valueAxis = new ValueAxis();
        valueAxis.Append(new AxisId {
            Val = axisId.Val
        });
        valueAxis.Append(scaling);
        valueAxis.Append(new Delete {
            Val = (BooleanValue)false
        });
        valueAxis.Append(new AxisPosition {
            Val = (EnumValue<AxisPositionValues>)position
        });
        valueAxis.Append(new MajorGridlines());
        valueAxis.Append(new NumberingFormat {
            FormatCode = (StringValue)"General",
            SourceLinked = (BooleanValue)false
        });
        valueAxis.Append(new MajorTickMark {
            Val = (EnumValue<TickMarkValues>)TickMarkValues.None
        });
        valueAxis.Append(new TickLabelPosition {
            Val = (EnumValue<TickLabelPositionValues>)TickLabelPositionValues.NextTo
        });
        valueAxis.Append(GenerateChartShapeProperties(9525));
        valueAxis.Append(textProperties);
        valueAxis.Append(new CrossingAxis {
            Val = crossingAxisId.Val
        });
        valueAxis.Append(new Crosses {
            Val = (EnumValue<CrossesValues>)CrossesValues.AutoZero
        });
        valueAxis.Append(new CrossBetween {
            Val = (EnumValue<CrossBetweenValues>)CrossBetweenValues.Between
        });
        return valueAxis;
    }

    private static ChartShapeProperties GenerateChartShapeProperties(int width)
    {
        var solidFill = new SolidFill();
        solidFill.Append(new RgbColorModelHex {
            Val = (HexBinaryValue)"000000"
        });
        var outline = new Outline {
            Width = (Int32Value)width
        };
        outline.Append(solidFill);
        outline.Append(new PresetDash {
            Val = (EnumValue<PresetLineDashValues>)PresetLineDashValues.Solid
        });
        var chartShapeProperties = new ChartShapeProperties();
        chartShapeProperties.Append(outline);
        return chartShapeProperties;
    }

    private static Legend GenerateLegend(LegendPositionValues position)
    {
        var paragraphProperties = new ParagraphProperties();
        paragraphProperties.Append(new DefaultRunProperties());
        var paragraph = new Paragraph();
        paragraph.Append(paragraphProperties);
        paragraph.Append(new EndParagraphRunProperties());
        var textProperties = new TextProperties();
        textProperties.Append(new BodyProperties());
        textProperties.Append(new ListStyle());
        textProperties.Append(paragraph);
        var legend = new Legend();
        legend.Append(new LegendPosition {
            Val = (EnumValue<LegendPositionValues>)position
        });
        legend.Append(new Layout());
        legend.Append(new Overlay {
            Val = (BooleanValue)false
        });
        legend.Append(textProperties);
        return legend;
    }
}