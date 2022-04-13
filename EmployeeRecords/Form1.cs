using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EmployeeRecords
{
    public partial class mainForm : Form
    {
        List<Employee> employeeDB = new List<Employee>();
        XmlReader reader = XmlReader.Create("XMLFile1.xml");

        public mainForm()
        {
            InitializeComponent();
            loadDB();
        }

        private void addButton_Click(object sender, EventArgs e)
        { 
            ClearLabels();

            string id  = idInput.Text;
            string firstName = fnInput.Text;
            string lastName = lnInput.Text;
            string date = dateInput.Text;
            string salary = salaryInput.Text;


        }

        private void removeButton_Click(object sender, EventArgs e)
        {
           
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            foreach(Employee emp in employeeDB)
            {

            }
        }

        private void ClearLabels()
        {
            idInput.Text = "";
            fnInput.Text = "";
            lnInput.Text = "";
            dateInput.Text = "";
            salaryInput.Text = "";

            Employee employee = new Employee(id, firstName, lastName, date, salary);
            employeeDB.Add(employee);
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public void loadDB()
        {
            XmlReader reader = XmlReader.Create("Resources/emplyeeData.xml");

            while(reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    string id = reader.ReadString();

                    reader.ReadToNextSibling("FirstName");
                    string firstName = reader.ReadString();

                    reader.ReadToNextSibling("LastName");
                    string lastName = reader.ReadString();

                    reader.ReadToNextSibling("date");
                    string date = reader.ReadString();

                    reader.ReadToNextSibling("pay");
                    string salary = reader.ReadString();

                    Employee employee = new Employee(id, firstName, lastName, date, salary);
                    employeeDB.Add(employee);
                }
            }
            reader.Close();

        }

        public void saveDB()
        {

        }
    }
}
