﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCustomComponents
{
    public partial class CustomTreeCell : UserControl
    {
        public void Clear()
        {
            treeView.Nodes.Clear();
        }

        //Публичное свойство для установки и получения индекса выбранной ветки(set, get).
        protected DataTreeNodeConfig Levels { get; set; }

        public void LoadConfig(DataTreeNodeConfig levels)
        {
            if (levels != null)
            {
                Levels = levels;
            }
        }

        //Публичный метод для получения выбранной записи(для конечного элемента дерева)
        public T GetSelectedObject<T>() where T : class, new()
        {
            if (treeView.SelectedNode == null || Levels == null || treeView.SelectedNode.Nodes.Count > 0)
            {
                return null;
            }

            Stack<string> stack = new Stack<string>();
            for (TreeNode treeNode = treeView.SelectedNode; treeNode != null; treeNode = treeNode.Parent)
            {
                stack.Push(treeNode.Text);
            }

            if (stack.Count != Levels.NodeNames.Count)
            {
                return null;
            }

            T val = new T();
            foreach (string nodeName in Levels.NodeNames)
            {
                PropertyInfo property = val.GetType().GetProperty(nodeName);
                string value = stack.Pop();
                property?.SetValue(val, Convert.ChangeType(value, property?.PropertyType));
            }

            return val;
        }

        //параметризованный метод, у которого в
        //передаваемых параметрах идет объект какого-то класса, и
        //имя свойства/поля, до которого согласно иерархии, следует
        //сформировать ветки.
        public void AddCell<T>(int columnIndex, T element)
        {
            if (Levels == null || element == null || columnIndex < 0 || columnIndex >= Levels.NodeNames.Count)
            {
                return;
            }

            TreeNodeCollection treeNodeCollection = treeView.Nodes;
            int num = 0;
            foreach (string nodeName in Levels.NodeNames)
            {
                string text = element.GetType().GetProperty(nodeName)?.GetValue(element, null)?.ToString() ?? nodeName;
                TreeNode treeNode = null;
                foreach (TreeNode item in treeNodeCollection)
                {
                    if (item.Text == text)
                    {
                        treeNode = item;
                    }
                }

                treeNodeCollection = ((treeNode == null) ? treeNodeCollection.Add(text).Nodes : treeNode.Nodes);
                if (num >= columnIndex)
                {
                    break;
                }

                num++;
            }
        }

        public CustomTreeCell()
        {
            InitializeComponent();
        }
    }
}
