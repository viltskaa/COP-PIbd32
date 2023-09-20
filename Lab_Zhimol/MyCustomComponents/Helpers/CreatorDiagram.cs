using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using MyCustomComponents.Models;

namespace MyCustomComponents.Helpers
{
    public class CreatorDiagram
    {
        private static uint order = 0u;

        private static uint index = 1u;

        public static DocumentFormat.OpenXml.Drawing.Charts.Chart GeneratePieChart(WordWithDiagramConfig config)
        {
            PieChart pieChart = new PieChart();
            pieChart.Append(GeneratePieChartSeries(config.Data.First().Key, config.Data.First().Value));
            PlotArea plotArea = new PlotArea();
            plotArea.Append(new Layout());
            plotArea.Append(pieChart);
            return GenerateChart(config.ChartTitle, plotArea, config.LegendLocation);
        }

        private static DocumentFormat.OpenXml.Drawing.Charts.Chart GenerateChart(string titleText, PlotArea plotArea, Location legendLocation)
        {
            DocumentFormat.OpenXml.Drawing.Charts.Chart chart = new DocumentFormat.OpenXml.Drawing.Charts.Chart();
            if (titleText.HaveText())
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

        private static PieChartSeries GeneratePieChartSeries(string seriesName, List<(int Date, double Value)> data)
        {
            PieChartSeries pieChartSeries = new PieChartSeries();
            pieChartSeries.Append(new DocumentFormat.OpenXml.Drawing.Charts.Index
            {
                Val = (UInt32Value)index
            });
            pieChartSeries.Append(new Order
            {
                Val = (UInt32Value)order
            });
            pieChartSeries.Append(GenerateSeriesText(seriesName));
            pieChartSeries.Append(GenerateCategoryAxisData(data.Select(((int Date, double Value) c) => c.Date.ToString()).ToArray()));
            pieChartSeries.Append(GenerateValues(data.Select(((int Date, double Value) v) => v.Value).ToArray()));
            index++;
            order++;
            return pieChartSeries;
        }

    }
}
