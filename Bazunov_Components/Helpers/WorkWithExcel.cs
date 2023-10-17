using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Bazunov_Components.Models;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Drawing;

namespace Bazunov_Components.Helpers;

public class WorkWithExcel : IContext
{
    private uint _index;
    private SheetData? _sheetData;
    private uint _startRowIndex;
    private Columns? _columns;
    private DocumentFormat.OpenXml.Drawing.Charts.Chart? _chart;

    private SheetData SheetData => _sheetData ??= new SheetData();
    private Columns Columns => _columns ??= new Columns();

    public void CreateBarChart(ChartConfig config)
    {
        _chart = ChartGenerator.GenerateBarChart(config);
    }
    public void CreateMultiHeader<T>(TableWithHeaderConfig<T> config)
    {
        var counter = 1u;
        var num = 2;
        if (config.ColumnsRowsWidth != null)
        {
            foreach (var item in config.ColumnsRowsWidth.Where(x => x.Column > 0))
            {
                Columns.Append(new Column
                {
                    Min = (UInt32Value)counter,
                    Max = (UInt32Value)counter,
                    Width = (DoubleValue)(item.Column * num),
                    CustomWidth = (BooleanValue)true
                });
                counter++;
            }

            counter = _startRowIndex;
            num = 5;
            if ((from r in SheetData.Elements<Row>()
                    where (uint)r.RowIndex == counter
                    select r).Any())
            {
                var row = (from r in SheetData.Elements<Row>()
                    where (uint)r.RowIndex == counter
                    select r).First();
                row.Height = (DoubleValue)(config.ColumnsRowsWidth[0].Row * num);
                row.CustomHeight = (BooleanValue)true;
            }
            else
            {
                SheetData.Append(new Row
                {
                    RowIndex = (UInt32Value)counter,
                    Height = (DoubleValue)(config.ColumnsRowsWidth[0].Row * num),
                    CustomHeight = (BooleanValue)true
                });
            }
        }

        const uint styleIndex = 2u;
        if (config.Headers == null) return;
        {
            var num3 = config.Headers.Count(x => x.ColumnIndex > 0);
            CreateCell(0, _startRowIndex, config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x is { ColumnIndex: 0, RowIndex: 0 }).Item3, styleIndex);
            for (var i = 0; i < num3; i++)
            {
                CreateCell(i + 1, _startRowIndex, config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == i + 1 && x.RowIndex == 0).Item3, styleIndex);
            }
        }
    }
    private static void GenerateStyle(OpenXmlPartContainer workbookPart)
    {
        var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
        workbookStylesPart.Stylesheet = new Stylesheet();
        var fonts = new DocumentFormat.OpenXml.Spreadsheet.Fonts {
            Count = (UInt32Value)2u,
            KnownFonts = BooleanValue.FromBoolean(value: true)
        };
        fonts.Append(new DocumentFormat.OpenXml.Spreadsheet.Font {
            FontSize = new FontSize
            {
                Val = (DoubleValue)11.0
            },
            FontName = new FontName
            {
                Val = (StringValue)"Calibri"
            },
            FontFamilyNumbering = new FontFamilyNumbering
            {
                Val = (Int32Value)2
            },
            FontScheme = new DocumentFormat.OpenXml.Spreadsheet.FontScheme
            {
                Val = new EnumValue<FontSchemeValues>(FontSchemeValues.Minor)
            }
        });
        fonts.Append(new DocumentFormat.OpenXml.Spreadsheet.Font {
            FontSize = new FontSize
            {
                Val = (DoubleValue)11.0
            },
            FontName = new FontName
            {
                Val = (StringValue)"Calibri"
            },
            FontFamilyNumbering = new FontFamilyNumbering
            {
                Val = (Int32Value)2
            },
            FontScheme = new DocumentFormat.OpenXml.Spreadsheet.FontScheme
            {
                Val = new EnumValue<FontSchemeValues>(FontSchemeValues.Minor)
            },
            Bold = new Bold()
        });
        workbookStylesPart.Stylesheet.Append(fonts);
        var fills = new Fills {
            Count = (UInt32Value)1u
        };
        fills.Append(new DocumentFormat.OpenXml.Spreadsheet.Fill {
            PatternFill = new DocumentFormat.OpenXml.Spreadsheet.PatternFill
            {
                PatternType = new EnumValue<PatternValues>(PatternValues.None)
            }
        });
        workbookStylesPart.Stylesheet.Append(fills);
        var borders = new Borders {
            Count = (UInt32Value)2u
        };
        borders.Append(new Border {
            LeftBorder = new DocumentFormat.OpenXml.Spreadsheet.LeftBorder(),
            RightBorder = new DocumentFormat.OpenXml.Spreadsheet.RightBorder(),
            TopBorder = new DocumentFormat.OpenXml.Spreadsheet.TopBorder(),
            BottomBorder = new DocumentFormat.OpenXml.Spreadsheet.BottomBorder(),
            DiagonalBorder = new DiagonalBorder()
        });
        borders.Append(new Border {
            LeftBorder = new DocumentFormat.OpenXml.Spreadsheet.LeftBorder {
                Style = (EnumValue<BorderStyleValues>)BorderStyleValues.Thin
            },
            RightBorder = new DocumentFormat.OpenXml.Spreadsheet.RightBorder {
                Style = (EnumValue<BorderStyleValues>)BorderStyleValues.Thin
            },
            TopBorder = new DocumentFormat.OpenXml.Spreadsheet.TopBorder {
                Style = (EnumValue<BorderStyleValues>)BorderStyleValues.Thin
            },
            BottomBorder = new DocumentFormat.OpenXml.Spreadsheet.BottomBorder {
                Style = (EnumValue<BorderStyleValues>)BorderStyleValues.Thin
            }
        });
        workbookStylesPart.Stylesheet.Append(borders);
        var cellFormats = new CellFormats {
            Count = (UInt32Value)3u
        };
        cellFormats.Append(new CellFormat {
            NumberFormatId = (UInt32Value)0u,
            FormatId = (UInt32Value)0u,
            FontId = (UInt32Value)0u,
            BorderId = (UInt32Value)0u,
            FillId = (UInt32Value)0u
        });
        cellFormats.Append(new CellFormat {
            NumberFormatId = (UInt32Value)0u,
            FormatId = (UInt32Value)0u,
            FontId = (UInt32Value)0u,
            BorderId = (UInt32Value)1u,
            FillId = (UInt32Value)0u
        });
        cellFormats.Append(new CellFormat {
            NumberFormatId = (UInt32Value)0u,
            FormatId = (UInt32Value)0u,
            FontId = (UInt32Value)1u,
            BorderId = (UInt32Value)1u,
            FillId = (UInt32Value)0u,
            Alignment = new Alignment
            {
                Horizontal = (EnumValue<HorizontalAlignmentValues>)HorizontalAlignmentValues.Center,
                Vertical = (EnumValue<VerticalAlignmentValues>)VerticalAlignmentValues.Center,
                WrapText = (BooleanValue)true
            }
        });
        workbookStylesPart.Stylesheet.Append(cellFormats);
    }
    public void CreateHeader(string header)
    {
        _index = 1u;
        var cell = CreateCell("A", _index);
        var run = new DocumentFormat.OpenXml.Spreadsheet.Run();
        run.Append(new DocumentFormat.OpenXml.Spreadsheet.Text(header));
        run.RunProperties = new DocumentFormat.OpenXml.Spreadsheet.RunProperties(new Bold());
        var inlineString = new InlineString();
        inlineString.Append(run);
        cell.Append(inlineString);
        cell.DataType = (EnumValue<CellValues>)CellValues.InlineString;
        _index++;
    }
    public void CreateTable(string[,] data)
    {
        for (var i = 0; i < data.GetLength(0); i++)
            for (var j = 0; j < data.GetLength(1); j++)
                CreateCell(j, (uint)(i + _index), data[i, j], 2u);

        _index += (uint)data.GetLength(0);
    }
    private Cell CreateCell(string columnName, uint rowIndex)
    {
        var columnName2 = columnName;
        var text = columnName2 + rowIndex;
        Row row;
        if ((from r in SheetData.Elements<Row>()
                where (uint)r.RowIndex == rowIndex
                select r).Any()) {
            row = (from r in SheetData.Elements<Row>()
                where (uint)r.RowIndex == rowIndex
                select r).First();
        } else {
            row = new Row {
                RowIndex = (UInt32Value)rowIndex
            };
            SheetData.Append(row);
        }

        var cell = row.Elements<Cell>().FirstOrDefault(c => c.CellReference!.Value == columnName2 + rowIndex);
        if (cell != null) return cell;
        var referenceChild = row.Elements<Cell>()
            .FirstOrDefault(
                item => item.CellReference!.Value!.Length == text.Length && 
                string.Compare(item.CellReference!.Value, text, StringComparison.OrdinalIgnoreCase) > 0);

        cell = new Cell {
            CellReference = (StringValue)text
        };
        row.InsertBefore(cell, referenceChild);

        return cell;
    }
    private static string GetExcelColumnName(int columnNumber)
    {
        columnNumber++;
        var num = columnNumber;
        var text = string.Empty;
        while (num > 0)
        {
            var num2 = (num - 1) % 26;
            text = Convert.ToChar(65 + num2) + text;
            num = (num - num2) / 26;
        }

        return text;
    }
    private void CreateCell(int columnIndex, uint rowIndex, string text, uint styleIndex)
    {
        var cell = CreateCell(GetExcelColumnName(columnIndex), rowIndex);
        cell.CellValue = new CellValue(text);
        cell.DataType = (EnumValue<CellValues>)CellValues.String;
        cell.StyleIndex = (UInt32Value)styleIndex;
    }
    public void SaveDoc(string filepath)
    {
        if (string.IsNullOrEmpty(filepath))
        {
            throw new ArgumentNullException("File name is empty");
        }

        if (SheetData == null)
        {
            throw new ArgumentNullException("Dock body is empty! Nothing to save!");
        }

        using var spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook);
        var workbookPart = spreadsheetDocument.AddWorkbookPart();
        GenerateStyle(workbookPart);
        workbookPart.Workbook = new Workbook();
        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        worksheetPart.Worksheet = new Worksheet();
        if (_columns != null)
        {
            worksheetPart.Worksheet.Append(_columns);
        }

        worksheetPart.Worksheet.Append(SheetData);
        var sheets = spreadsheetDocument.WorkbookPart!.Workbook.AppendChild(new Sheets());
        var sheet = new Sheet {
            Id = (StringValue)spreadsheetDocument.WorkbookPart!.GetIdOfPart(worksheetPart),
            SheetId = (UInt32Value)1u,
            Name = (StringValue)"List 1"
        };
        sheets.Append(sheet);
        if (_chart == null) return;
        var drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
        worksheetPart.Worksheet.Append(new Drawing {
            Id = (StringValue)worksheetPart.GetIdOfPart(drawingsPart)
        });
        worksheetPart.Worksheet.Save();
        var chartPart = drawingsPart.AddNewPart<ChartPart>();
        chartPart.ChartSpace = new ChartSpace();
        chartPart.ChartSpace.Append(new EditingLanguage {
            Val = new StringValue("en-US")
        });
        chartPart.ChartSpace.Append(_chart);
        chartPart.ChartSpace.Save();
        drawingsPart.WorksheetDrawing = new WorksheetDrawing();
        var twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());
        twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(new ColumnId("2"), new ColumnOffset("581025"), new RowId("2"), new RowOffset("114300")));
        twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(new ColumnId("17"), new ColumnOffset("276225"), new RowId("32"), new RowOffset("0")));
        var graphicFrame = twoCellAnchor.AppendChild(new DocumentFormat.OpenXml.Drawing.Spreadsheet.GraphicFrame());
        graphicFrame.Macro = (StringValue)"";
        graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualGraphicFrameProperties(new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualDrawingProperties
        {
            Id = new UInt32Value(2u),
            Name = (StringValue)"Chart 1"
        }, new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualGraphicFrameDrawingProperties()));
        graphicFrame.Append(new Transform(new Offset {
            X = (Int64Value)0L,
            Y = (Int64Value)0L
        }, new Extents {
            Cx = (Int64Value)0L,
            Cy = (Int64Value)0L
        }));
        graphicFrame.Append(new Graphic(new GraphicData(new ChartReference {
            Id = (StringValue)drawingsPart.GetIdOfPart(chartPart)
        }) {
            Uri = (StringValue)"http://schemas.openxmlformats.org/drawingml/2006/chart"
        }));
        twoCellAnchor.Append(new ClientData());
        drawingsPart.WorksheetDrawing.Save();
    }
    public void CreateTableWithHeader()
    {
        _startRowIndex = _index;
    }
    public void LoadDataToTableWithMultiHeader(string[,] data, int rowHeight)
    {
        const int num = 5;
        for (var i = 0u; i < data.GetLength(0); i++)
        {
            if ((from r in SheetData.Elements<Row>()
                    where (uint)r.RowIndex == i + 1
                    select r).Any())
            {
                var row = (from r in SheetData.Elements<Row>()
                    where (uint)r.RowIndex == i + 1
                    select r).First();
                row.Height = (DoubleValue)(rowHeight * num);
                row.CustomHeight = (BooleanValue)true;
            }
            else
            {
                SheetData.Append(new Row
                {
                    RowIndex = (UInt32Value)(i + 1),
                    Height = (DoubleValue)(rowHeight * num),
                    CustomHeight = (BooleanValue)true
                });
            }
        }

        _startRowIndex++;
        for (var j = 0; j < data.GetLength(0); j++)
        {
            for (var k = 0; k < data.GetLength(1); k++)
            {
                CreateCell(k, _startRowIndex, data[j, k], k == 0 ? 2u : 1u);
            }

            _startRowIndex++;
        }
    }
}