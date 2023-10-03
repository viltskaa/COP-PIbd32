using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml;
using Bazunov_Components.Models;
using Index = DocumentFormat.OpenXml.Drawing.Charts.Index;
using Orientation = DocumentFormat.OpenXml.Drawing.Charts.Orientation;

namespace Bazunov_Components.Helpers
{
    public class ChartGenerator
    {
        private static uint order = 0u;

        private static uint index = 1u;

        public static DocumentFormat.OpenXml.Drawing.Charts.Chart GenerateBarChart(ChartConfig config)
        {
            AxisId axisId = new AxisId
            {
                Val = (UInt32Value)97045504u
            };
            AxisId axisId2 = new AxisId
            {
                Val = (UInt32Value)97055488u
            };
            BarChart barChart = new BarChart();
            barChart.Append(new BarDirection
            {
                Val = (EnumValue<BarDirectionValues>)BarDirectionValues.Column
            });
            barChart.Append(new BarGrouping
            {
                Val = (EnumValue<BarGroupingValues>)BarGroupingValues.Clustered
            });
            barChart.Append(GenerateBarChartSeries(config.Data.First().Key, config.Data.First().Value));
            barChart.Append(axisId);
            barChart.Append(axisId2);
            Outline outline = new Outline
            {
                Width = (Int32Value)25400
            };
            outline.Append(new NoFill());
            DocumentFormat.OpenXml.Drawing.Charts.ShapeProperties shapeProperties = new DocumentFormat.OpenXml.Drawing.Charts.ShapeProperties();
            shapeProperties.Append(new NoFill());
            shapeProperties.Append(outline);
            PlotArea plotArea = new PlotArea();
            plotArea.Append(new Layout());
            plotArea.Append(barChart);
            plotArea.Append(GenerateCategoryAxis(axisId, AxisPositionValues.Bottom, axisId2));
            plotArea.Append(GenerateValueAxis(axisId2, AxisPositionValues.Left, axisId));
            plotArea.Append(shapeProperties);
            return GenerateChart(config.ChartTitle, plotArea, config.LegendLocation);
        }

        private static DocumentFormat.OpenXml.Drawing.Charts.Chart GenerateChart(string titleText, PlotArea plotArea, Location legendLocation)
        {
            DocumentFormat.OpenXml.Drawing.Charts.Chart chart = new DocumentFormat.OpenXml.Drawing.Charts.Chart();
            if (string.IsNullOrWhiteSpace(titleText))
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

            LegendPositionValues position = legendLocation switch
            {
                Location.Top => LegendPositionValues.Top,
                Location.Rigth => LegendPositionValues.Right,
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
            Run run = new Run();
            run.Append(new RunProperties
            {
                FontSize = (Int32Value)1100
            });
            run.Append(new Text(titleText));
            ParagraphProperties paragraphProperties = new ParagraphProperties();
            paragraphProperties.Append(new DefaultRunProperties
            {
                FontSize = (Int32Value)1100
            });
            Paragraph paragraph = new Paragraph();
            paragraph.Append(paragraphProperties);
            paragraph.Append(run);
            RichText richText = new RichText();
            richText.Append(new BodyProperties());
            richText.Append(new ListStyle());
            richText.Append(paragraph);
            ChartText chartText = new ChartText();
            chartText.Append(richText);
            Title title = new Title();
            title.Append(chartText);
            title.Append(new Layout());
            title.Append(new Overlay
            {
                Val = (BooleanValue)false
            });
            return title;
        }

        private static BarChartSeries GenerateBarChartSeries(string seriesName, List<(int Date, double Value)> data)
        {
            BarChartSeries barChartSeries = new BarChartSeries();
            barChartSeries.Append(new Index
            {
                Val = (UInt32Value)index
            });
            barChartSeries.Append(new Order
            {
                Val = (UInt32Value)order
            });
            barChartSeries.Append(GenerateSeriesText(seriesName));
            barChartSeries.Append(GenerateCategoryAxisData(data.Select(((int Date, double Value) c) => c.Date.ToString()).ToArray()));
            barChartSeries.Append(GenerateValues(data.Select(((int Date, double Value) v) => v.Value).ToArray()));
            index++;
            order++;
            return barChartSeries;
        }

        private static SeriesText GenerateSeriesText(string seriesName)
        {
            StringPoint stringPoint = new StringPoint
            {
                Index = (UInt32Value)0u
            };
            stringPoint.Append(new NumericValue
            {
                Text = seriesName
            });
            StringCache stringCache = new StringCache();
            stringCache.Append(new PointCount
            {
                Val = (UInt32Value)1u
            });
            stringCache.Append(stringPoint);
            StringReference stringReference = new StringReference();
            stringReference.Append(stringCache);
            SeriesText seriesText = new SeriesText();
            seriesText.Append(stringReference);
            return seriesText;
        }

        private static CategoryAxisData GenerateCategoryAxisData(string[] data)
        {
            uint num = (uint)data.Length;
            NumberingCache numberingCache = GenerateNumberingCache(num);
            for (uint num2 = 0u; num2 < num; num2++)
            {
                numberingCache.Append(GenerateNumericPoint(num2, data[num2].ToString()));
            }

            NumberReference numberReference = new NumberReference();
            numberReference.Append(numberingCache);
            CategoryAxisData categoryAxisData = new CategoryAxisData();
            categoryAxisData.Append(numberReference);
            return categoryAxisData;
        }

        private static Values GenerateValues(double[] data)
        {
            uint num = (uint)data.Length;
            NumberingCache numberingCache = GenerateNumberingCache(num);
            for (uint num2 = 0u; num2 < num; num2++)
            {
                numberingCache.Append(GenerateNumericPoint(num2, data[num2].ToString()));
            }

            NumberReference numberReference = new NumberReference();
            numberReference.Append(numberingCache);
            Values values = new Values();
            values.Append(numberReference);
            return values;
        }

        private static NumberingCache GenerateNumberingCache(uint numPoints)
        {
            NumberingCache numberingCache = new NumberingCache();
            numberingCache.Append(new FormatCode
            {
                Text = "General"
            });
            numberingCache.Append(new PointCount
            {
                Val = (UInt32Value)numPoints
            });
            return numberingCache;
        }

        private static NumericPoint GenerateNumericPoint(UInt32Value idx, string text)
        {
            NumericPoint numericPoint = new NumericPoint
            {
                Index = idx
            };
            numericPoint.Append(new NumericValue
            {
                Text = text
            });
            return numericPoint;
        }

        private static CategoryAxis GenerateCategoryAxis(AxisId axisId, AxisPositionValues axisPosition, AxisId crossingAxisId)
        {
            Scaling scaling = new Scaling();
            scaling.Append(new Orientation
            {
                Val = (EnumValue<OrientationValues>)OrientationValues.MinMax
            });
            SolidFill solidFill = new SolidFill();
            solidFill.Append(new RgbColorModelHex
            {
                Val = (HexBinaryValue)"000000"
            });
            DefaultRunProperties defaultRunProperties = new DefaultRunProperties
            {
                FontSize = (Int32Value)1000,
                Bold = (BooleanValue)false,
                Italic = (BooleanValue)false,
                Underline = (EnumValue<TextUnderlineValues>)TextUnderlineValues.None,
                Strike = (EnumValue<TextStrikeValues>)TextStrikeValues.NoStrike,
                Baseline = (Int32Value)0
            };
            defaultRunProperties.Append(solidFill);
            ParagraphProperties paragraphProperties = new ParagraphProperties();
            paragraphProperties.Append(defaultRunProperties);
            Paragraph paragraph = new Paragraph();
            paragraph.Append(paragraphProperties);
            paragraph.Append(new EndParagraphRunProperties());
            TextProperties textProperties = new TextProperties();
            textProperties.Append(new BodyProperties
            {
                Rotation = (Int32Value)(-1800000),
                Vertical = (EnumValue<TextVerticalValues>)TextVerticalValues.Horizontal
            });
            textProperties.Append(new ListStyle());
            textProperties.Append(paragraph);
            CategoryAxis categoryAxis = new CategoryAxis();
            categoryAxis.Append(new AxisId
            {
                Val = axisId.Val
            });
            categoryAxis.Append(scaling);
            categoryAxis.Append(new AxisPosition
            {
                Val = (EnumValue<AxisPositionValues>)axisPosition
            });
            categoryAxis.Append(new NumberingFormat
            {
                FormatCode = (StringValue)"General",
                SourceLinked = (BooleanValue)true
            });
            categoryAxis.Append(new TickLabelPosition
            {
                Val = (EnumValue<TickLabelPositionValues>)TickLabelPositionValues.Low
            });
            categoryAxis.Append(GenerateChartShapeProperties(3175));
            categoryAxis.Append(textProperties);
            categoryAxis.Append(new CrossingAxis
            {
                Val = crossingAxisId.Val
            });
            categoryAxis.Append(new Crosses
            {
                Val = (EnumValue<CrossesValues>)CrossesValues.AutoZero
            });
            categoryAxis.Append(new AutoLabeled
            {
                Val = (BooleanValue)true
            });
            categoryAxis.Append(new LabelAlignment
            {
                Val = (EnumValue<LabelAlignmentValues>)LabelAlignmentValues.Center
            });
            categoryAxis.Append(new LabelOffset
            {
                Val = (UInt16Value)(ushort)100
            });
            categoryAxis.Append(new TickLabelSkip
            {
                Val = (Int32Value)1
            });
            categoryAxis.Append(new TickMarkSkip
            {
                Val = (Int32Value)1
            });
            return categoryAxis;
        }
        private static DateAxis GenerateDateAxis(AxisId axisId, AxisPositionValues axisPosition, AxisId crossingAxisId, TickLabelPositionValues tickLabelPosition)
        {
            Scaling scaling = new Scaling();
            scaling.Append(new Orientation
            {
                Val = (EnumValue<OrientationValues>)OrientationValues.MinMax
            });
            ParagraphProperties paragraphProperties = new ParagraphProperties();
            paragraphProperties.Append(new DefaultRunProperties());
            Paragraph paragraph = new Paragraph();
            paragraph.Append(paragraphProperties);
            paragraph.Append(new EndParagraphRunProperties());
            TextProperties textProperties = new TextProperties();
            textProperties.Append(new BodyProperties
            {
                Rotation = (Int32Value)(-5400000),
                Vertical = (EnumValue<TextVerticalValues>)TextVerticalValues.Horizontal
            });
            textProperties.Append(new ListStyle());
            textProperties.Append(paragraph);
            DateAxis dateAxis = new DateAxis();
            dateAxis.Append(new AxisId
            {
                Val = axisId.Val
            });
            dateAxis.Append(scaling);
            dateAxis.Append(new Delete
            {
                Val = (BooleanValue)false
            });
            dateAxis.Append(new AxisPosition
            {
                Val = (EnumValue<AxisPositionValues>)axisPosition
            });
            dateAxis.Append(new NumberingFormat
            {
                FormatCode = (StringValue)"General",
                SourceLinked = (BooleanValue)true
            });
            dateAxis.Append(new MajorTickMark
            {
                Val = (EnumValue<TickMarkValues>)TickMarkValues.None
            });
            dateAxis.Append(new TickLabelPosition
            {
                Val = (EnumValue<TickLabelPositionValues>)tickLabelPosition
            });
            dateAxis.Append(textProperties);
            dateAxis.Append(new CrossingAxis
            {
                Val = crossingAxisId.Val
            });
            dateAxis.Append(new Crosses
            {
                Val = (EnumValue<CrossesValues>)CrossesValues.AutoZero
            });
            dateAxis.Append(new AutoLabeled
            {
                Val = (BooleanValue)true
            });
            dateAxis.Append(new LabelOffset
            {
                Val = (UInt16Value)(ushort)100
            });
            return dateAxis;
        }

        private static ValueAxis GenerateValueAxis(AxisId axisId, AxisPositionValues position, AxisId crossingAxisId)
        {
            Scaling scaling = new Scaling();
            scaling.Append(new Orientation
            {
                Val = (EnumValue<OrientationValues>)OrientationValues.MinMax
            });
            ParagraphProperties paragraphProperties = new ParagraphProperties();
            paragraphProperties.Append(new DefaultRunProperties());
            Paragraph paragraph = new Paragraph();
            paragraph.Append(paragraphProperties);
            paragraph.Append(new EndParagraphRunProperties());
            TextProperties textProperties = new TextProperties();
            textProperties.Append(new BodyProperties());
            textProperties.Append(new ListStyle());
            textProperties.Append(paragraph);
            ValueAxis valueAxis = new ValueAxis();
            valueAxis.Append(new AxisId
            {
                Val = axisId.Val
            });
            valueAxis.Append(scaling);
            valueAxis.Append(new Delete
            {
                Val = (BooleanValue)false
            });
            valueAxis.Append(new AxisPosition
            {
                Val = (EnumValue<AxisPositionValues>)position
            });
            valueAxis.Append(new MajorGridlines());
            valueAxis.Append(new NumberingFormat
            {
                FormatCode = (StringValue)"General",
                SourceLinked = (BooleanValue)false
            });
            valueAxis.Append(new MajorTickMark
            {
                Val = (EnumValue<TickMarkValues>)TickMarkValues.None
            });
            valueAxis.Append(new TickLabelPosition
            {
                Val = (EnumValue<TickLabelPositionValues>)TickLabelPositionValues.NextTo
            });
            valueAxis.Append(GenerateChartShapeProperties(9525));
            valueAxis.Append(textProperties);
            valueAxis.Append(new CrossingAxis
            {
                Val = crossingAxisId.Val
            });
            valueAxis.Append(new Crosses
            {
                Val = (EnumValue<CrossesValues>)CrossesValues.AutoZero
            });
            valueAxis.Append(new CrossBetween
            {
                Val = (EnumValue<CrossBetweenValues>)CrossBetweenValues.Between
            });
            return valueAxis;
        }

        private static ChartShapeProperties GenerateChartShapeProperties(int width)
        {
            SolidFill solidFill = new SolidFill();
            solidFill.Append(new RgbColorModelHex
            {
                Val = (HexBinaryValue)"000000"
            });
            Outline outline = new Outline
            {
                Width = (Int32Value)width
            };
            outline.Append(solidFill);
            outline.Append(new PresetDash
            {
                Val = (EnumValue<PresetLineDashValues>)PresetLineDashValues.Solid
            });
            ChartShapeProperties chartShapeProperties = new ChartShapeProperties();
            chartShapeProperties.Append(outline);
            return chartShapeProperties;
        }

        private static Legend GenerateLegend(LegendPositionValues position)
        {
            ParagraphProperties paragraphProperties = new ParagraphProperties();
            paragraphProperties.Append(new DefaultRunProperties());
            Paragraph paragraph = new Paragraph();
            paragraph.Append(paragraphProperties);
            paragraph.Append(new EndParagraphRunProperties());
            TextProperties textProperties = new TextProperties();
            textProperties.Append(new BodyProperties());
            textProperties.Append(new ListStyle());
            textProperties.Append(paragraph);
            Legend legend = new Legend();
            legend.Append(new LegendPosition
            {
                Val = (EnumValue<LegendPositionValues>)position
            });
            legend.Append(new Layout());
            legend.Append(new Overlay
            {
                Val = (BooleanValue)false
            });
            legend.Append(textProperties);
            return legend;
        }
    }
}
