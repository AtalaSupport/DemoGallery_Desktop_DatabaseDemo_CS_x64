using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using Atalasoft.Imaging;
using WinDemoHelperMethods;

namespace DatabaseDemo
{

	public class FormMain : System.Windows.Forms.Form
	{
		private string CONNECTION_STRING;

		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnOpen;
		private Atalasoft.Imaging.WinControls.WorkspaceViewer workspaceViewer1;
		private System.Windows.Forms.Button btnSaveToDatabase;
		private System.Windows.Forms.TextBox txtCaption;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOpenFromDatabase;
		private System.Windows.Forms.Button AboutBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            //CONNECTION_STRING = "Data Source=; Initial Catalog=; user id=; password=;"
            // NOTE: this is the x86 version
			//CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + "images.mdb;User ID=Admin;";
            // NOTE this is for x64
			CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + "images.mdb;User ID=Admin;";
            HelperMethods.PopulateDecoders(Atalasoft.Imaging.Codec.RegisteredDecoders.Decoders);
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnOpen = new System.Windows.Forms.Button();
			this.workspaceViewer1 = new Atalasoft.Imaging.WinControls.WorkspaceViewer();
			this.btnSaveToDatabase = new System.Windows.Forms.Button();
			this.txtCaption = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOpenFromDatabase = new System.Windows.Forms.Button();
			this.AboutBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(4, 4);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(88, 23);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open from File";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// workspaceViewer1
			// 
			this.workspaceViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.workspaceViewer1.DisplayProfile = null;
			this.workspaceViewer1.Location = new System.Drawing.Point(0, 64);
			this.workspaceViewer1.Magnifier.BackColor = System.Drawing.Color.White;
			this.workspaceViewer1.Magnifier.BorderColor = System.Drawing.Color.Black;
			this.workspaceViewer1.Magnifier.Size = new System.Drawing.Size(100, 100);
			this.workspaceViewer1.Name = "workspaceViewer1";
			this.workspaceViewer1.OutputProfile = null;
			this.workspaceViewer1.Selection = null;
			this.workspaceViewer1.Size = new System.Drawing.Size(464, 212);
			this.workspaceViewer1.TabIndex = 1;
			this.workspaceViewer1.Text = "workspaceViewer1";
			this.workspaceViewer1.ZoomRectangle = null;
			// 
			// btnSaveToDatabase
			// 
			this.btnSaveToDatabase.Location = new System.Drawing.Point(100, 4);
			this.btnSaveToDatabase.Name = "btnSaveToDatabase";
			this.btnSaveToDatabase.Size = new System.Drawing.Size(108, 23);
			this.btnSaveToDatabase.TabIndex = 2;
			this.btnSaveToDatabase.Text = "Save To Database";
			this.btnSaveToDatabase.Click += new System.EventHandler(this.btnSaveToDatabase_Click);
			// 
			// txtCaption
			// 
			this.txtCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCaption.Location = new System.Drawing.Point(56, 32);
			this.txtCaption.Name = "txtCaption";
			this.txtCaption.Size = new System.Drawing.Size(400, 20);
			this.txtCaption.TabIndex = 3;
			this.txtCaption.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Caption:";
			// 
			// btnOpenFromDatabase
			// 
			this.btnOpenFromDatabase.Location = new System.Drawing.Point(216, 4);
			this.btnOpenFromDatabase.Name = "btnOpenFromDatabase";
			this.btnOpenFromDatabase.Size = new System.Drawing.Size(128, 23);
			this.btnOpenFromDatabase.TabIndex = 5;
			this.btnOpenFromDatabase.Text = "Open From Database";
			this.btnOpenFromDatabase.Click += new System.EventHandler(this.btnOpenFromDatabase_Click);
			// 
			// AboutBtn
			// 
			this.AboutBtn.Location = new System.Drawing.Point(352, 3);
			this.AboutBtn.Name = "AboutBtn";
			this.AboutBtn.Size = new System.Drawing.Size(104, 24);
			this.AboutBtn.TabIndex = 6;
			this.AboutBtn.Text = "About ...";
			this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 278);
			this.Controls.Add(this.AboutBtn);
			this.Controls.Add(this.btnOpenFromDatabase);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCaption);
			this.Controls.Add(this.btnSaveToDatabase);
			this.Controls.Add(this.workspaceViewer1);
			this.Controls.Add(this.btnOpen);
			this.Name = "FormMain";
			this.Text = "Database Demo";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog1.Filter = HelperMethods.CreateDialogFilter(true);
			if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				this.workspaceViewer1.Open(openFileDialog1.FileName);
			}
		}

		private void btnSaveToDatabase_Click(object sender, System.EventArgs e)
		{
			try
			{
				//SaveToSqlDatabase(workspaceViewer1.Image);
				SaveToOleDatabase(workspaceViewer1.Image);
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void SaveToSqlDatabase(AtalaImage image)
		{
			SqlConnection myConnection = null;
			try
			{
				//save image to byte array and allocate enough memory for the image
				byte[] imagedata = image.ToByteArray(new Atalasoft.Imaging.Codec.JpegEncoder(75));

				//create the SQL statement to add the image data
				myConnection = new SqlConnection(CONNECTION_STRING);
				SqlCommand myCommand = new SqlCommand("INSERT INTO Atalasoft_Image_Database (Caption, ImageData) VALUES ('" + txtCaption.Text + "', @Image)", myConnection);
				SqlParameter myParameter = new SqlParameter("@Image", SqlDbType.Image, imagedata.Length);
				myParameter.Value = imagedata;
				myCommand.Parameters.Add(myParameter);

				//open the connection and execture the statement
				myConnection.Open();
				myCommand.ExecuteNonQuery();
			}
			finally
			{
				myConnection.Close();
			}
		}

		private void SaveToOleDatabase(AtalaImage image)
		{
			OleDbConnection myConnection = null;
			try
			{
				//save image to byte array and allocate enough memory for the image
				byte[] imagedata = image.ToByteArray(new Atalasoft.Imaging.Codec.JpegEncoder(75));

				//create the SQL statement to add the image data
				myConnection = new OleDbConnection(CONNECTION_STRING);
				OleDbCommand myCommand = new OleDbCommand("INSERT INTO Atalasoft_Image_Database (Caption, ImageData) VALUES ('" + txtCaption.Text + "', ?)", myConnection);
				OleDbParameter myParameter = new OleDbParameter("@Image", OleDbType.LongVarBinary, imagedata.Length);
				myParameter.Value = imagedata;
				myCommand.Parameters.Add(myParameter);

				//open the connection and execture the statement
				myConnection.Open();
				myCommand.ExecuteNonQuery();
			}
			finally
			{
				myConnection.Close();
			}
		}

		private void btnOpenFromDatabase_Click(object sender, System.EventArgs e)
		{
			try
			{
				//workspaceViewer1.Image = OpenFromSqlDatabase();
				workspaceViewer1.Image = OpenFromOleDatabase();
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private AtalaImage OpenFromSqlDatabase()
		{
			SqlConnection myConnection = null;
			try
			{
				//establish connection and SELECT statement
				myConnection = new SqlConnection(CONNECTION_STRING);
				SqlCommand myCommand = new SqlCommand("SELECT ImageData FROM Atalasoft_Image_Database WHERE Caption = '" + txtCaption.Text + "'", myConnection);
				myConnection.Open();

				//get the image from the database
				byte[] imagedata = (byte[])myCommand.ExecuteScalar();
				if (imagedata != null)
				{
					return AtalaImage.FromByteArray(imagedata);
				}
				else
				{
					MessageBox.Show("Image does not exist in database.");
					return null;
				}
			}
			finally
			{
				myConnection.Close();
			}
		}

		private AtalaImage OpenFromOleDatabase()
		{
			OleDbConnection myConnection = null;
			try
			{
				//establish connection and SELECT statement
				myConnection = new OleDbConnection(CONNECTION_STRING);
				OleDbCommand myCommand = new OleDbCommand("SELECT ImageData FROM [Atalasoft_Image_Database] WHERE Caption = '" + txtCaption.Text + "'", myConnection);
				myConnection.Open();

				//get the image from the database
				byte[] imagedata = (byte[])myCommand.ExecuteScalar();
				if (imagedata != null)
				{
					return AtalaImage.FromByteArray(imagedata);
				}
				else
				{
					MessageBox.Show("Image does not exist in database.");
					return null;
				}

			}
			finally
			{
				myConnection.Close();
			}
		}

		private void AboutBtn_Click(object sender, System.EventArgs e)
		{
			AtalaDemos.AboutBox.About aboutBox = new AtalaDemos.AboutBox.About("About Atalasoft DotImage Database Demo",
				"DotImage Database Demo");
			aboutBox.Description = @"Demonstrates how to open an image from a database and save it back.  There is a sample MS Access database included.  The source code for this demo shows this functionality with an OLE database and can be easily modified to work with other data sources such as SQL.";
			aboutBox.ShowDialog();
		}
	}
}
