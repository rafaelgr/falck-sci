using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace PaintCellsOfGrid
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid myDataGrid;
		private System.Windows.Forms.Button exitBtn;
		private System.Data.DataSet myDataSet;
		private   DataGridTableStyle DGStyle;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			try
			{
				string connString=@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\Test.mdb" ;
				
				OleDbConnection myConn=new OleDbConnection(connString) ;
				string sqlString="SELECT * FROM Table1" ;
				myDataSet = new DataSet() ; 
				myConn.Open() ;
				OleDbDataAdapter myOleDbAdapter = new OleDbDataAdapter(sqlString, myConn) ;
				myOleDbAdapter.Fill(myDataSet,"Table1") ;


				CreateDataGridStyle();
				myDataGrid.TableStyles.Add(DGStyle);

				myDataGrid.SetDataBinding(myDataSet,"Table1");

			}
			catch(Exception myE)
			{
				MessageBox.Show("Problem!!" + myE.ToString());

			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.myDataGrid = new System.Windows.Forms.DataGrid();
			this.exitBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// myDataGrid
			// 
			this.myDataGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.myDataGrid.DataMember = "";
			this.myDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid.Name = "myDataGrid";
			this.myDataGrid.ReadOnly = true;
			this.myDataGrid.Size = new System.Drawing.Size(368, 224);
			this.myDataGrid.TabIndex = 0;
			// 
			// exitBtn
			// 
			this.exitBtn.Location = new System.Drawing.Point(136, 248);
			this.exitBtn.Name = "exitBtn";
			this.exitBtn.TabIndex = 1;
			this.exitBtn.Text = "Exit";
			this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 293);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.exitBtn,
																		  this.myDataGrid});
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void exitBtn_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void CreateDataGridStyle() 
		{
			DataGridColumnStyle GridDelColumn;
			DataGridColumnStyle GridSeqStyle;
			DGStyle = new DataGridTableStyle();

			DGStyle.MappingName = "Table1";

			GridSeqStyle = new DataGridTextBoxColumn();
			GridSeqStyle.MappingName = "Column1";
			GridSeqStyle.HeaderText = "Column1";
			GridSeqStyle.Width = 100;
			DGStyle.GridColumnStyles.Add(GridSeqStyle);

			PropertyDescriptorCollection pcol = this.BindingContext[myDataSet, "Table1"].GetItemProperties();

			GridDelColumn = new ColumnStyle(pcol["Table1"]);
			GridDelColumn.MappingName = "Column2";
			GridDelColumn.HeaderText = "Column2";
			GridDelColumn.Width = 100;
			DGStyle.GridColumnStyles.Add(GridDelColumn);

			DGStyle.AllowSorting         = true;
			DGStyle.RowHeadersVisible    = true;
		}
	}
}
