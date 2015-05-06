using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section2CC

	// Rose Collins Student ID 90048876
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		// input validation on length, width, avg depth values as three sep funcs

		const float txtLengthUpper = 50;
		const float txtLengthLower = 5;
		const float txtWidthUpper = 20;
		const float txtWidthLower = 2;
		const float txtAvgDepthUpper = 4;
		const float txtAvgDepthLower = 2;



		private void btnCalculate_Click( object sender, EventArgs e )
		{
			if( !ValidLength( float.Parse( txtLength.Text ) ) )
			{
				return;
			}
			if( !ValidWidth( float.Parse( txtWidth.Text ) ) )
			{
				return;
			}
			if( !ValidAvgDepth( float.Parse( txtAvgDepth.Text ) ) )
			{
				return;
			}

			var PoolLength = float.Parse( txtLength.Text );
			var PoolWidth = float.Parse( txtWidth.Text );
			var TotalSurfaceArea = CalculateSurfaceArea( PoolLength, PoolWidth );
			var PoolAvgDepth = float.Parse( txtAvgDepth.Text );
			var PoolVolume = CalculateVolume( PoolLength, PoolWidth, PoolAvgDepth );
			lblCategory.Text = CalculatePoolCategory( PoolVolume );
			WriteTempToAvgTempBox();
			HeatCostPerMonth( PoolVolume );
		}





		//function to calculate the surface area of the pool
		float CalculateSurfaceArea( float length, float width )
		{
			var tsa = length * width;
			txtSurfaceArea.Text = tsa.ToString("0.00");
			return tsa;
		}



		//function to calculate the volume of the pool 
		float CalculateVolume( float length, float width, float avgdepth )
		{
			var PoolVolume = length * width * avgdepth * 1000;
			txtVolume.Text = PoolVolume.ToString();
			return PoolVolume;
		}




		//function to calculate pool category based on size  
		string CalculatePoolCategory( float volume )
		{
			if( volume < 500000 )
			{
				return "Pool category: Small";
			}
			else if( volume < 1500000 )
			{
				return "Pool category: Medium";
			}
			else
			{
				return "Pool category: Large";
			}
		}



		// function to write temperature to average temperature box
		void WriteTempToAvgTempBox()
		{
			txtTableAvgTemp.Text = "";
			for( float temperature = 5; temperature <= 23; temperature += 1.5f )
			{
				txtTableAvgTemp.Text += temperature.ToString() + "\r\n";
			}
		}



		// function to calculate and write heating cost per month to $ per month box
		void HeatCostPerMonth( float volume )
		{
			txtTableDollars.Text = "";
			for( float temperature = 5; temperature < 23; temperature += 1.5f )
			{
				txtTableDollars.Text += (( 25 - temperature ) * volume / 32500).ToString("0") + "\r\n";
			}

        }




		//the following section has the boolean tests for the numbers input for length/width/avgdepth input fields

		bool ValidLength( float LengthValueTest )	 //testing the validity of the length that has been entered
		{
			string Message;
			if( LengthValueTest > txtLengthLower && LengthValueTest < txtLengthUpper )
			{
				return true;
			}
			else
			{
				Message = "The length number entered is invalid.";
				MessageBox.Show( Message, "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				return false;
			}

		}

		bool ValidWidth( float WidthValueTest )	// testing the validity of the width that has been entered
		{
			string Message;
			if( WidthValueTest > txtWidthLower && WidthValueTest < txtWidthUpper )
			{
				return true;
			}
			else
			{
				Message = "The width number entered is invalid.";
				MessageBox.Show( Message, "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				return false;
			}
		}

		bool ValidAvgDepth( float AvgDepthValueTest )	 // testing the validity of the depth that has been entered
		{
			string Message;
			if( AvgDepthValueTest > txtAvgDepthLower && AvgDepthValueTest < txtAvgDepthUpper )
			{
				return true;
			}
			else
			{
				Message = "The average depth number entered is invalid.";
				MessageBox.Show( Message, "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
				return false;
			}
		}
	}
}
