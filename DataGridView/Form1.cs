using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
            this.dataGridView1.Rows[0].ReadOnly = true;
        }

        private int sum(DataGridView dataGridView, int cell)
        {
            int sum = 0;
            for (int i = 1; i < dataGridView.Rows.Count; i++)
            {
                var value = dataGridView.Rows[i].Cells[cell].Value;
                if (value != null)
                {
                    sum += int.Parse(value.ToString());
                }
            }
            return sum;

        }

        private void zeroToThousand(DataGridView dataGridView, int[] e)
        {
            
            var value = dataGridView.Rows[e[0]].Cells[e[1]].Value;
            if (value != null)
            {
                try
                {
                    int valueInt = int.Parse(value.ToString());
                    if (valueInt > 0 && valueInt <= 1000)
                    {
                        this.dataGridView1.Rows[0].Cells[e[1]].Value = this.sum(this.dataGridView1, e[1]);
                    }
                    else
                    {
                        MessageBox.Show("Wartość nie mieści się w przedziale od 0 do 1000");
                        this.dataGridView1.Rows[e[0]].Cells[e[1]].Value = null;
                    }
                }
                catch
                {
                    MessageBox.Show("Pole musi być numeryczne");
                    this.dataGridView1.Rows[e[0]].Cells[e[1]].Value = null;
                }
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            zeroToThousand((DataGridView)sender, new int[] { e.RowIndex, e.ColumnIndex });
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.E)
            {

                Form2 f = new Form2();
                f.ShowDialog();
                try
                {
                    int value = int.Parse(f.value);
                    DataGridView dataGridView = (DataGridView)sender;
                    bool selectedNewRow = false;
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[dataGridView1.Rows.Count - 1].Clone();
                    List<int[]> indexes = new List<int[]>();

                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        if (cell.RowIndex != 0 && cell.RowIndex != dataGridView.RowCount - 1)
                        {
                            cell.Value = f.value;
                            zeroToThousand(dataGridView, new int[] { cell.RowIndex, cell.ColumnIndex });
                        }
                        else if (cell.RowIndex == dataGridView.RowCount - 1)
                        {
                            selectedNewRow = true;
                            row.Cells[cell.ColumnIndex].Value = f.value;
                            indexes.Add(new int[] { cell.RowIndex, cell.ColumnIndex });
                        }
                    }
                    if (selectedNewRow)
                    {
                        dataGridView.Rows.Add(row);
                        foreach (var index in indexes)
                        {
                            zeroToThousand(dataGridView, index);
                        }
                    }
                    dataGridView.ClearSelection();
                }
                catch
                {
                    MessageBox.Show("Pole musi być numeryczne");
                }
            }
        }
    }
}
