using CustomComponent.Helpers;
using CustomComponent.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent
{
    public partial class ComponentTableToPdf : Component

    {

        private Document _document;
        private Table _table;
        private Chart _chart;

        private Document Document
        {
            get
            {
                if (this._document == null)
                {
                    this._document = new Document();
                }
                return this._document;
            }
        }

        private Table Table
        {
            get
            {
                if (this._table == null)
                    this._table = new Table();
                return this._table;
            }
        }
        public ComponentTableToPdf()
        {
            InitializeComponent();
        }

        public ComponentTableToPdf(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateHeader(string header)
        {
            var section = this.Document.AddSection();
            var paragraph = section.AddParagraph(header);
            paragraph.Format.Font.Color = Colors.Black;
            paragraph.Format.Font.Bold = true;
        }

        public void CreateTableWithHeader() => this.Table.Borders.Width = new Unit(0.75);

        private static void AddRowHeaderCellMergeByRows(int columnIndex, string header, Row row)
        {
            SetHeaderCell(columnIndex, header, row);
            row.Cells[columnIndex].MergeDown = 1;
        }

        private static void SetHeaderCell(int columnIndex, string header, Row row)
        {
            row.Cells[columnIndex].AddParagraph(header);
            row.Cells[columnIndex].Format.Font.Bold = true;
            row.Cells[columnIndex].Format.Alignment = (ParagraphAlignment)1;
            row.Cells[columnIndex].VerticalAlignment = (VerticalAlignment)1;
        }

        public void CreateRowHeader(ComponentDocumentWithTableHeaderConfig config)
        {
            foreach ((int Column, int Row) tuple in config.ColumnsRowsWidth)
                this.Table.AddColumn(new Unit(tuple.Column * 5));
            Row row1 = this.Table.AddRow();
            Row row2 = this.Table.AddRow();
            for (int i = 0; i < config.ColumnUnion[0].StartIndex; ++i)
                AddRowHeaderCellMergeByRows(i, config.Headers.FirstOrDefault(x => x.Item1 == i).Item3, row1);
            for (int i = 0; i < config.ColumnUnion.Count; i++)
            {
                SetHeaderCell(config.ColumnUnion[i].StartIndex, config.Headers.FirstOrDefault(x => x.Item1 == config.ColumnUnion[i].StartIndex && x.Item2 == 0).Item3, row1);
                row1.Cells[config.ColumnUnion[i].StartIndex].MergeRight = config.ColumnUnion[i].Count - 1;
                for (int j = config.ColumnUnion[i].StartIndex; j < config.ColumnUnion[i].StartIndex + config.ColumnUnion[i].Count; ++j)
                    SetHeaderCell(j, config.Headers.FirstOrDefault(x => x.Item1 == j && x.Item2 == 1).Item3, row2);
                if (i < config.ColumnUnion.Count - 1)
                {
                    for (int j = config.ColumnUnion[i].StartIndex + config.ColumnUnion[i].Count; j < config.ColumnUnion[i + 1].StartIndex; ++j)
                        AddRowHeaderCellMergeByRows(j, config.Headers.FirstOrDefault(x => x.Item1 == j).Item3, row1);
                }
            }
            List<(int StartIndex, int Count)> columnUnion1 = config.ColumnUnion;
            int startIndex = columnUnion1[columnUnion1.Count - 1].StartIndex;
            List<(int StartIndex, int Count)> columnUnion2 = config.ColumnUnion;
            int count = columnUnion2[columnUnion2.Count - 1].Count;
            int num = startIndex + count;
            for (int i = num; i < config.ColumnsRowsWidth.Count; ++i)
                AddRowHeaderCellMergeByRows(i, config.Headers.FirstOrDefault(x => x.Item1 == i).Item3, row1);
        }

        public void LoadDataToTableWithRowHeader(string[,] data)
        {
            for (int index1 = 0; index1 < data.GetLength(0); ++index1)
            {
                Row row = this.Table.AddRow();
                for (int index2 = 0; index2 < data.GetLength(1); ++index2)
                    row.Cells[index2].AddParagraph(data[index1, index2]);
            }
        }

        public void SaveDoc(string filepath)
        {
            if (filepath.IsEmpty())
                throw new ArgumentNullException("Имя файла не задано");
            if (this._document == null)
                throw new ArgumentNullException("Документ не сформирован, сохранять нечего");
            if (this._table != null)
                this._document.LastSection.Add(this._table);
            if (this._chart != null)
                this._document.LastSection.Add(this._chart);
            PdfDocumentRenderer documentRenderer = new PdfDocumentRenderer(true)
            {
                Document = this._document
            };
            documentRenderer.RenderDocument();
            documentRenderer.PdfDocument.Save(filepath);
        }

        public void CreateDoc<T>(ComponentTableToPdfConfig<T> config)
        {
            config.CheckFields();
            config.ColumnsRowsDataCount = (config.ColumnsRowsWidth.Count, config.Data.Count + 2);
            CreateHeader(config.Header);
            CreateTableWithHeader();
            CreateRowHeader(config);
            string[,] array = new string[config.Data.Count, config.ColumnsRowsWidth.Count];
            for (int j = 0; j < config.Data.Count; j++)
            {
                int i;
                for (i = 0; i < config.ColumnsRowsWidth.Count; i++)
                {
                    (int, int, string, string) tuple = config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == i && x.RowIndex == 1);
                    if (tuple.Equals(default((int, int, string, string))))
                    {
                        tuple = config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == i && x.RowIndex == 0);
                    }

                    array[j, i] = config.Data[j].GetType().GetProperty(tuple.Item4)!.GetValue(config.Data[j], null)!.ToString();
                }
            }

            LoadDataToTableWithRowHeader(array);
            SaveDoc(config.FilePath);
        }
    }
}
