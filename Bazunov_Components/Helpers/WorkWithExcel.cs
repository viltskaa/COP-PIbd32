using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Bazunov_Components.Models;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Drawing;

namespace Bazunov_Components.Helpers
{
    public class WorkWithExcel : IContext
    {
        private uint _index = 0u;
        private SheetData? _sheetData;
        private uint _startRowIndex = 0u;
        private Columns? _columns;
        private DocumentFormat.OpenXml.Drawing.Charts.Chart? _chart;

        private SheetData SheetData
        {
            get
            {
                if (_sheetData == null)
                {
                    _sheetData = new SheetData();
                }

                return _sheetData;
            }
        }
        private Columns Columns
        {
            get
            {
                if (_columns == null)
                {
                    _columns = new Columns();
                }

                return _columns;
            }
        }

        public void CreateBarChart(ChartConfig config)
        {
            _chart = ChartGenerator.GenerateBarChart(config);
        }
        public void CreateMultiHeader<T>(TableWithHeaderConfig<T> config)
        {
            uint counter = 1u;
            int num = 2;
            foreach (var item in config.ColumnsRowsWidth.Where(((int Column, int Row) x) => x.Column > 0))
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
                Row row = (from r in SheetData.Elements<Row>()
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

            uint styleIndex = 2u;
            int num2 = config.Headers.Where<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.RowIndex > 0).Count();
            int num3 = config.Headers.Where<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex > 0).Count();
            CreateCell(0, _startRowIndex, config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == 0 && x.RowIndex == 0).Item3, styleIndex);
            int i;
            for (i = 0; i < num3; i++)
            {
                CreateCell(i + 1, _startRowIndex, config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == i + 1 && x.RowIndex == 0).Item3, styleIndex);
            }
        }
        private static void GenerateStyle(WorkbookPart workbookPart)
        {
            WorkbookStylesPart workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
            workbookStylesPart.Stylesheet = new Stylesheet();
            DocumentFormat.OpenXml.Spreadsheet.Fonts fonts = new DocumentFormat.OpenXml.Spreadsheet.Fonts
            {
                Count = (UInt32Value)2u,
                KnownFonts = BooleanValue.FromBoolean(value: true)
            };
            fonts.Append(new DocumentFormat.OpenXml.Spreadsheet.Font
            {
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
            fonts.Append(new DocumentFormat.OpenXml.Spreadsheet.Font
            {
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
            Fills fills = new Fills
            {
                Count = (UInt32Value)1u
            };
            fills.Append(new DocumentFormat.OpenXml.Spreadsheet.Fill
            {
                PatternFill = new DocumentFormat.OpenXml.Spreadsheet.PatternFill
                {
                    PatternType = new EnumValue<PatternValues>(PatternValues.None)
                }
            });
            workbookStylesPart.Stylesheet.Append(fills);
            Borders borders = new Borders
            {
                Count = (UInt32Value)2u
            };
            borders.Append(new Border
            {
                LeftBorder = new DocumentFormat.OpenXml.Spreadsheet.LeftBorder(),
                RightBorder = new DocumentFormat.OpenXml.Spreadsheet.RightBorder(),
                TopBorder = new DocumentFormat.OpenXml.Spreadsheet.TopBorder(),
                BottomBorder = new DocumentFormat.OpenXml.Spreadsheet.BottomBorder(),
                DiagonalBorder = new DiagonalBorder()
            });
            borders.Append(new Border
            {
                LeftBorder = new DocumentFormat.OpenXml.Spreadsheet.LeftBorder
                {
                    Style = (EnumValue<BorderStyleValues>)BorderStyleValues.Thin
                },
                RightBorder = new DocumentFormat.OpenXml.Spreadsheet.RightBorder
                {
                    Style = (EnumValue<BorderStyleValues>)BorderStyleValues.Thin
                },
                TopBorder = new DocumentFormat.OpenXml.Spreadsheet.TopBorder
                {
                    Style = (EnumValue<BorderStyleValues>)BorderStyleValues.Thin
                },
                BottomBorder = new DocumentFormat.OpenXml.Spreadsheet.BottomBorder
                {
                    Style = (EnumValue<BorderStyleValues>)BorderStyleValues.Thin
                }
            });
            workbookStylesPart.Stylesheet.Append(borders);
            CellFormats cellFormats = new CellFormats
            {
                Count = (UInt32Value)3u
            };
            cellFormats.Append(new CellFormat
            {
                NumberFormatId = (UInt32Value)0u,
                FormatId = (UInt32Value)0u,
                FontId = (UInt32Value)0u,
                BorderId = (UInt32Value)0u,
                FillId = (UInt32Value)0u
            });
            cellFormats.Append(new CellFormat
            {
                NumberFormatId = (UInt32Value)0u,
                FormatId = (UInt32Value)0u,
                FontId = (UInt32Value)0u,
                BorderId = (UInt32Value)1u,
                FillId = (UInt32Value)0u
            });
            cellFormats.Append(new CellFormat
            {
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
            Cell cell = CreateCell("A", _index);
            DocumentFormat.OpenXml.Spreadsheet.Run run = new DocumentFormat.OpenXml.Spreadsheet.Run();
            run.Append(new DocumentFormat.OpenXml.Spreadsheet.Text(header));
            run.RunProperties = new DocumentFormat.OpenXml.Spreadsheet.RunProperties(new Bold());
            InlineString inlineString = new InlineString();
            inlineString.Append(run);
            cell.Append(inlineString);
            cell.DataType = (EnumValue<CellValues>)CellValues.InlineString;
            _index++;
        }
        public void CreateTable(string[,] data)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    CreateCell(j, (uint)(i + _index), data[i, j], 1u);
                }
            }

            _index += (uint)data.GetLength(0);
        }
        private Cell CreateCell(string columnName, uint rowIndex)
        {
            string columnName2 = columnName;
            string text = columnName2 + rowIndex;
            Row row;
            if ((from r in SheetData.Elements<Row>()
                 where (uint)r.RowIndex == rowIndex
                 select r).Any())
            {
                row = (from r in SheetData.Elements<Row>()
                       where (uint)r.RowIndex == rowIndex
                       select r).First();
            }
            else
            {
                row = new Row
                {
                    RowIndex = (UInt32Value)rowIndex
                };
                SheetData.Append(row);
            }

            Cell cell = row.Elements<Cell>().FirstOrDefault((Cell c) => c.CellReference!.Value == columnName2 + rowIndex);
            if (cell == null)
            {
                Cell referenceChild = null;
                foreach (Cell item in row.Elements<Cell>())
                {
                    if (item.CellReference!.Value!.Length == text.Length && string.Compare(item.CellReference!.Value, text, ignoreCase: true) > 0)
                    {
                        referenceChild = item;
                        break;
                    }
                }

                cell = new Cell
                {
                    CellReference = (StringValue)text
                };
                row.InsertBefore(cell, referenceChild);
            }

            return cell;
        }
        private static string GetExcelColumnName(int columnNumber)
        {
            columnNumber++;
            int num = columnNumber;
            string text = string.Empty;
            while (num > 0)
            {
                int num2 = (num - 1) % 26;
                text = Convert.ToChar(65 + num2) + text;
                num = (num - num2) / 26;
            }

            return text;
        }
        private void CreateCell(int columnIndex, uint rowIndex, string text, uint styleIndex)
        {
            Cell cell = CreateCell(GetExcelColumnName(columnIndex), rowIndex);
            cell.CellValue = new CellValue(text);
            cell.DataType = (EnumValue<CellValues>)CellValues.String;
            cell.StyleIndex = (UInt32Value)styleIndex;
        }
        public void SaveDoc(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                throw new ArgumentNullException("Имя файла не задано");
            }

            if (SheetData == null)
            {
                throw new ArgumentNullException("Документ не сформирован, сохранять нечего");
            }

            using SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook);
            WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
            GenerateStyle(workbookPart);
            workbookPart.Workbook = new Workbook();
            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet();
            if (_columns != null)
            {
                worksheetPart.Worksheet.Append(_columns);
            }

            worksheetPart.Worksheet.Append(SheetData);
            Sheets sheets = spreadsheetDocument.WorkbookPart!.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet
            {
                Id = (StringValue)spreadsheetDocument.WorkbookPart!.GetIdOfPart(worksheetPart),
                SheetId = (UInt32Value)1u,
                Name = (StringValue)"Лист 1"
            };
            sheets.Append(sheet);
            if (_chart != null)
            {
                DrawingsPart drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
                worksheetPart.Worksheet.Append(new Drawing
                {
                    Id = (StringValue)worksheetPart.GetIdOfPart(drawingsPart)
                });
                worksheetPart.Worksheet.Save();
                ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
                chartPart.ChartSpace = new ChartSpace();
                chartPart.ChartSpace.Append(new EditingLanguage
                {
                    Val = new StringValue("en-US")
                });
                chartPart.ChartSpace.Append(_chart);
                chartPart.ChartSpace.Save();
                drawingsPart.WorksheetDrawing = new WorksheetDrawing();
                TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());
                twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(new ColumnId("2"), new ColumnOffset("581025"), new RowId("2"), new RowOffset("114300")));
                twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(new ColumnId("17"), new ColumnOffset("276225"), new RowId("32"), new RowOffset("0")));
                DocumentFormat.OpenXml.Drawing.Spreadsheet.GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new DocumentFormat.OpenXml.Drawing.Spreadsheet.GraphicFrame());
                graphicFrame.Macro = (StringValue)"";
                graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualGraphicFrameProperties(new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualDrawingProperties
                {
                    Id = new UInt32Value(2u),
                    Name = (StringValue)"Chart 1"
                }, new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualGraphicFrameDrawingProperties()));
                graphicFrame.Append(new Transform(new Offset
                {
                    X = (Int64Value)0L,
                    Y = (Int64Value)0L
                }, new Extents
                {
                    Cx = (Int64Value)0L,
                    Cy = (Int64Value)0L
                }));
                graphicFrame.Append(new Graphic(new GraphicData(new ChartReference
                {
                    Id = (StringValue)drawingsPart.GetIdOfPart(chartPart)
                })
                {
                    Uri = (StringValue)"http://schemas.openxmlformats.org/drawingml/2006/chart"
                }));
                twoCellAnchor.Append(new ClientData());
                drawingsPart.WorksheetDrawing.Save();
            }
        }
        public void CreateTableWithHeader()
        {
            _startRowIndex = _index;
        }
        public void LoadDataToTableWithMultiHeader(string[,] data, int rowHeight)
        {
            int num = 5;
            uint i;
            for (i = 0u; i < data.GetLength(0); i++)
            {
                if ((from r in SheetData.Elements<Row>()
                     where (uint)r.RowIndex == i + 1
                     select r).Any())
                {
                    Row row = (from r in SheetData.Elements<Row>()
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

            uint styleIndex = 2u;
            uint styleIndex2 = 1u;
            _startRowIndex++;
            for (int j = 0; j < data.GetLength(0); j++)
            {
                for (int k = 0; k < data.GetLength(1); k++)
                {
                    if (k == 0)
                    {
                        CreateCell(0, _startRowIndex, data[j, k], styleIndex);
                    }
                    else
                    {
                        CreateCell(k, _startRowIndex, data[j, k], styleIndex2);
                    }
                }

                _startRowIndex++;
            }
        }
    }
}
