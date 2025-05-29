// InputForm.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryWindowsForms
{
    public partial class InputForm : Form
    {
        // Dictionary to hold textboxes for dynamic input fields
        private Dictionary<string, TextBox> inputTextBoxes = new Dictionary<string, TextBox>();
        private Dictionary<string, Label> inputLabels = new Dictionary<string, Label>();
        private Dictionary<string, CheckBox> inputCheckBoxes = new Dictionary<string, CheckBox>();
        private int currentY = 20; // Starting Y position for controls

        public Dictionary<string, string> InputValues { get; private set; }
        public Dictionary<string, bool> CheckBoxValues { get; private set; }

        /// <summary>
        /// Constructor for adding new records.
        /// </summary>
        /// <param name="title">Title of the form.</param>
        /// <param name="fields">List of field names to display as textboxes.</param>
        /// <param name="checkboxFields">List of field names to display as checkboxes.</param>
        public InputForm(string title, List<string> fields, List<string> checkboxFields = null)
        {
            InitializeComponent(); // Call the designer-generated method
            this.Text = title;
            this.StartPosition = FormStartPosition.CenterParent; // Center relative to parent form
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // No resizing
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CreateInputControls(fields, checkboxFields);
        }

        /// <summary>
        /// Constructor for editing existing records.
        /// </summary>
        /// <param name="title">Title of the form.</param>
        /// <param name="fieldValues">Dictionary of field names and their current values.</param>
        /// <param name="checkboxValues">Dictionary of checkbox field names and their current boolean values.</param>
        public InputForm(string title, Dictionary<string, string> fieldValues, Dictionary<string, bool> checkboxValues = null)
        {
            InitializeComponent(); // Call the designer-generated method
            this.Text = title;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            List<string> fields = new List<string>(fieldValues.Keys);
            List<string> checkboxFields = checkboxValues != null ? new List<string>(checkboxValues.Keys) : null;

            CreateInputControls(fields, checkboxFields, fieldValues, checkboxValues);
        }

        private void CreateInputControls(List<string> fields, List<string> checkboxFields, Dictionary<string, string> initialValues = null, Dictionary<string, bool> initialCheckboxValues = null)
        {
            // Clear existing controls if any (important for designer reloads)
            // Note: InitializeComponent() might add some default controls, so clear after it.
            this.Controls.Clear();
            inputTextBoxes.Clear();
            inputLabels.Clear();
            inputCheckBoxes.Clear();
            currentY = 20; // Reset Y position

            // Create TextBoxes for string/numeric inputs
            foreach (string fieldName in fields)
            {
                Label lbl = new Label();
                lbl.Text = fieldName + ":";
                lbl.Location = new Point(30, currentY);
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 10F);
                this.Controls.Add(lbl);
                inputLabels.Add(fieldName, lbl);

                TextBox txt = new TextBox();
                txt.Name = "txt" + fieldName.Replace(" ", ""); // Remove spaces for Name
                txt.Location = new Point(150, currentY);
                txt.Size = new Size(200, 25);
                txt.Font = new Font("Segoe UI", 10F);
                if (initialValues != null && initialValues.ContainsKey(fieldName))
                {
                    txt.Text = initialValues[fieldName];
                }
                this.Controls.Add(txt);
                inputTextBoxes.Add(fieldName, txt);

                currentY += 40; // Move down for next control
            }

            // Create CheckBoxes for boolean inputs
            if (checkboxFields != null)
            {
                foreach (string fieldName in checkboxFields)
                {
                    CheckBox chk = new CheckBox();
                    chk.Text = fieldName;
                    chk.Location = new Point(150, currentY);
                    chk.AutoSize = true;
                    chk.Font = new Font("Segoe UI", 10F);
                    if (initialCheckboxValues != null && initialCheckboxValues.ContainsKey(fieldName))
                    {
                        chk.Checked = initialCheckboxValues[fieldName];
                    }
                    this.Controls.Add(chk);
                    inputCheckBoxes.Add(fieldName, chk);

                    currentY += 30; // Move down for next control
                }
            }

            // Add Save Button
            Button btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new Point(150, currentY + 20);
            btnSave.Size = new Size(80, 30);
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            // Add Cancel Button
            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(270, currentY + 20);
            btnCancel.Size = new Size(80, 30);
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.Click += BtnCancel_Click;
            this.Controls.Add(btnCancel);

            // Adjust form size based on content
            this.ClientSize = new Size(400, currentY + 80);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            InputValues = new Dictionary<string, string>();
            CheckBoxValues = new Dictionary<string, bool>();

            // Collect values from textboxes
            foreach (var entry in inputTextBoxes)
            {
                InputValues.Add(entry.Key, entry.Value.Text);
            }

            // Collect values from checkboxes
            foreach (var entry in inputCheckBoxes)
            {
                CheckBoxValues.Add(entry.Key, entry.Value.Checked);
            }

            this.DialogResult = DialogResult.OK; // Set dialog result to OK
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Set dialog result to Cancel
            this.Close();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }
    }
}
