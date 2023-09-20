using MyCustomComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents.Helpers
{
    public static class ExtensionConfig
    {
        public static void CheckFields(this WordConfig config)
        {
            if (config.FilePath.IsEmpty())
            {
                throw new ArgumentNullException("Имя файла не задано");
            }

            if (config.Header.IsEmpty())
            {
                throw new ArgumentNullException("Заголовок документа не задан");
            }
        }
        public static void CheckFields(this WordWithImageConfig config)
        {
            ((WordConfig)config).CheckFields();
            if (config.Images == null || config.Images.Count == 0 || config.Images.All((byte[] x) => x == null || x.Length == 0))
            {
                throw new ArgumentNullException("Нет изображений для вставки в документ");
            }
        }
        public static void CheckFields<T>(this WordWithTableDataConfig<T> config)
        {
            WordWithTableDataConfig<T> config2 = config;
            ((WordConfig)config2).CheckFields();
            if (config2.ColumnsRowsWidth == null || config2.ColumnsRowsWidth.Count == 0)
            {
                throw new ArgumentNullException("Нет данных по ширине колонок таблицы");
            }

            if (config2.UseUnion && (config2.ColumnUnion == null || config2.ColumnUnion.Count == 0))
            {
                throw new ArgumentNullException("Нет данных по объединению колонок таблицы");
            }

            if (config2.Headers == null || config2.Headers.Count == 0 || config2.Headers.Any<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.Header.IsEmpty()))
            {
                throw new ArgumentNullException("Нет данных по заголовкам таблицы");
            }

            if (config2.Data == null || config2.Data.Count == 0)
            {
                throw new ArgumentNullException("Нет данных для заполнения таблицы");
            }

            if (!config2.UseUnion)
            {
                return;
            }

            if (config2.ColumnsRowsWidth.Count < config2.ColumnUnion[config2.ColumnUnion.Count - 1].StartIndex + config2.ColumnUnion[config2.ColumnUnion.Count - 1].Count - 1)
            {
                throw new IndexOutOfRangeException("Последнее объединение ячеек выходит за границы таблицы");
            }

            int k;
            for (k = 0; k < config2.ColumnUnion[0].StartIndex; k++)
            {
                int num = config2.Headers.Where<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == k).Count();
                if (num == 0)
                {
                    DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 1);
                    defaultInterpolatedStringHandler.AppendLiteral("Для ");
                    defaultInterpolatedStringHandler.AppendFormatted(k);
                    defaultInterpolatedStringHandler.AppendLiteral(" колонки отсутствует заголовок");
                    throw new ArgumentNullException(defaultInterpolatedStringHandler.ToStringAndClear());
                }

                if (num > 1)
                {
                    DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 1);
                    defaultInterpolatedStringHandler.AppendLiteral("Для ");
                    defaultInterpolatedStringHandler.AppendFormatted(k);
                    defaultInterpolatedStringHandler.AppendLiteral(" колонки задано более 1 заголовка");
                    throw new ArgumentNullException(defaultInterpolatedStringHandler.ToStringAndClear());
                }
            }

            int j;
            for (j = 0; j < config2.ColumnUnion.Count; j++)
            {
                if (j < config2.ColumnUnion.Count - 1 && config2.ColumnUnion[j].StartIndex + config2.ColumnUnion[j].Count - 1 > config2.ColumnUnion[j + 1].StartIndex)
                {
                    throw new IndexOutOfRangeException("Имеется накладка в объединении ячеек");
                }

                int num2 = config2.Headers.Where<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex >= config2.ColumnUnion[j].StartIndex && x.ColumnIndex <= config2.ColumnUnion[j].StartIndex + config2.ColumnUnion[j].Count - 1 && x.RowIndex == 0).Count();
                if (num2 == 0)
                {
                    throw new ArgumentNullException("Для колонок 0 строки отсутствует заголовок");
                }

                if (num2 > 1)
                {
                    throw new ArgumentNullException("Для колонок 0 строки задано более 1 заголовка");
                }

                num2 = config2.Headers.Where<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex >= config2.ColumnUnion[j].StartIndex && x.ColumnIndex <= config2.ColumnUnion[j].StartIndex + config2.ColumnUnion[j].Count - 1 && x.RowIndex == 1).Count();
                if (num2 < config2.ColumnUnion[j].Count)
                {
                    throw new ArgumentNullException("Для колонок 1 строки не хватает заголовков");
                }

                if (num2 > config2.ColumnUnion[j].Count)
                {
                    throw new ArgumentNullException("Для колонок 1 строки задано более требуемого числа заголовков");
                }

                if (j < config2.ColumnUnion.Count - 1)
                {
                    num2 = config2.Headers.Where<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex >= config2.ColumnUnion[j].StartIndex + config2.ColumnUnion[j].Count && x.ColumnIndex < config2.ColumnUnion[j + 1].StartIndex && x.RowIndex == 0).Count();
                    if (num2 < config2.ColumnUnion[j + 1].StartIndex - (config2.ColumnUnion[j].StartIndex + config2.ColumnUnion[j].Count))
                    {
                        throw new ArgumentNullException("Для колонок не хватает заголовков");
                    }

                    if (num2 > config2.ColumnUnion[j + 1].StartIndex - (config2.ColumnUnion[j].StartIndex + config2.ColumnUnion[j].Count))
                    {
                        throw new ArgumentNullException("Для колонок задано более требуемого числа заголовков");
                    }

                    num2 = config2.Headers.Where<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex >= config2.ColumnUnion[j].StartIndex + config2.ColumnUnion[j].Count && x.ColumnIndex < config2.ColumnUnion[j + 1].StartIndex && x.RowIndex == 1).Count();
                    if (num2 > 0)
                    {
                        throw new ArgumentNullException("Для колонок заданы заголовки 2 уровня, чего быть не должно");
                    }
                }
                int i;
                for (i = config2.ColumnUnion[config2.ColumnUnion.Count - 1].StartIndex + config2.ColumnUnion[config2.ColumnUnion.Count - 1].Count; i < config2.ColumnsRowsWidth.Count; i++)
                {
                    int num3 = config2.Headers.Where<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == i).Count();
                    if (num3 == 0)
                    {
                        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 1);
                        defaultInterpolatedStringHandler.AppendLiteral("Для ");
                        defaultInterpolatedStringHandler.AppendFormatted(i);
                        defaultInterpolatedStringHandler.AppendLiteral(" колонки отсутствует заголовок");
                        throw new ArgumentNullException(defaultInterpolatedStringHandler.ToStringAndClear());
                    }

                    if (num3 > 1)
                    {
                        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 1);
                        defaultInterpolatedStringHandler.AppendLiteral("Для ");
                        defaultInterpolatedStringHandler.AppendFormatted(i);
                        defaultInterpolatedStringHandler.AppendLiteral(" колонки задано более 1 заголовка");
                        throw new ArgumentNullException(defaultInterpolatedStringHandler.ToStringAndClear());
                    }
                }
            }
        }
    }
}
