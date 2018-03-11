﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryConversionApplication
{
    public partial class Form1 : Form
    {
        // Custom classes coded to validate & convert user inputs
        private BinaryValidator myValidator = new BinaryValidator();
        private BinaryConverter myConverter = new BinaryConverter();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Prepare form / check default values
            this.txtOutputBinary.ReadOnly = true;
            this.radUnsigned.Checked = true;
            this.radDecimalOut.Checked = true;
        }

        
        private void btnConvert_Click(object sender, EventArgs e)
        {
            // Get user input
            string userInput = this.getUserInput();
            string validatedBinaryInput;

            // Get starting representation type
            bool fromUnisgned, fromSigned, fromOnes, fromTwos, fromDecimal;

            fromUnisgned = this.radUnsigned.Checked;
            fromSigned = this.radSigned.Checked;
            fromOnes = this.radOnesComp.Checked;
            fromTwos = this.radTwosComp.Checked;
            fromDecimal = this.radDecimal.Checked;

            // Get ending representation type
            bool toUnsigned, toSigned, toOnes, toTwos, toDecimal;

            toUnsigned = this.radUnsignedOut.Checked;
            toSigned = this.radSignedOut.Checked;
            toOnes = this.radOnesOut.Checked;
            toTwos = this.radTwosOut.Checked;
            toDecimal = this.radDecimalOut.Checked;
            
            // Only run binary validations if actually converting from a binary value (eg. not a decimal)
            if (!this.radDecimal.Checked)
            {
                // Validate the binary input
                if (myValidator.ValidateUserInput(userInput))
                {
                    // Input is valid - continue
                    validatedBinaryInput = userInput;
                }
                else
                {
                    // Input is not valid - stop
                    MessageBox.Show(text: "Oops! Please make sure you input either an 8 bit or a 4 bit binary value or, alternatively, a decimal value. Please try again.");
                }
            }
            else
            {
                int userInputValue;

                // Validate decimal input
                if (int.TryParse(userInput, out userInputValue))
                {
                    // Functional - come back here when ready
                }
                else
                {
                    MessageBox.Show(text: "Oops! Please make sure you input a decimal value. Please try again.");
                }
            }
        }

        // Method used to retrieve user input from form
        private string getUserInput()
        {
            string userInput = "";

            try
            {
                userInput = this.txtInputBinary.Text;
            }
            catch (Exception err)
            {
                MessageBox.Show("Oops! " + err.Message + " Please try again.");
            }

            return userInput;
        }

        private string[] getConversionParams()
        {
            return new string[] { "from", "to" };
        }
    }
}
