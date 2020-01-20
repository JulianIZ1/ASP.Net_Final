using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
namespace WebFinalProject
{
    public class DBConnection
    {
            public SqlClient.SqlConnection connString = new SqlClient.SqlConnection("server=CNSA07E-SVR; initial catalog=REFILL_PROJECT; integrated security=SSPI; connect timeout=10;");
            public SqlClient.SqlCommand cmdString = new SqlClient.SqlCommand();
            public string Reply, Reply2;
            public SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
            public DataSet aDataSet = new DataSet();
            public string userPassword = "";
            public string hidePassword = "";
            public string strResult;
            public string UserType;
            private byte[] key = new[] { };
            private byte[] IV = new[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        public void LoginCheck(object username)
        {

            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                try
                {
                    if ((username.Length != 5) | (username == "Username") | (username == null))
                    {
                        return Reply == "Bad Login";
                        return;
                    }
                    UserType = username.Substring(0, 1);
                    {
                        var withBlock = cmdString;
                        withBlock.Connection = connString;
                        withBlock.CommandType = CommandType.StoredProcedure;
                        withBlock.CommandTimeout = 900;
                        switch (UserType)
                        {
                            case object _ when ("P").ToUpper():
                                {
                                    withBlock.CommandText = "CHECKPATIENTS";
                                    withBlock.Parameters.Add("@PATIENT_ID", SqlDbType.VarChar, 5).Value = username;
                                    break;
                                }

                            case object _ when ("D").ToUpper():
                                {
                                    withBlock.CommandText = "CHECKPHYSICIANS";
                                    withBlock.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = username;
                                    break;
                                }

                            default:
                                {
                                    Reply = "Bad Login";
                                    return Reply;
                                    return;
                                }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Reply == "Login Error";
                    return;
                }
            }
            catch (Exception ex)
            {
                return Reply == "No DB";
                return;
            }
            return Reply == "";
        }
        public void ViewPatients()
        {
            try
            {
                connString.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = connString;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "VIEWPATIENTS";
                SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();
                aAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connString.Close();
            }
        }
        public void ViewPhysicians()
        {
            try
            {
                connString.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = connString;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "VIEWPHYSICIANS";
                SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();
                aAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connString.Close();
            }
        }
        public void ViewPrescriptions()
        {
            try
            {
                connString.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = connString;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "VIEWPRESCRIPTIONS";
                SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();
                aAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connString.Close();
            }
        }
        public void GetPatientByID(object patientID)
        {
            try
            {
                connString.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = connString;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "CHECKPATIENTS";
                cmdString.Parameters.Add("@PATIENT_ID", SqlDbType.VarChar, 5).Value = patientID;
                SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();
                aAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connString.Close();
            }
        }
        public void GetPhysicianByID(object physicianID)
        {
            try
            {
                connString.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = connString;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "CHECKPHYSICIANS";
                cmdString.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = physicianID;
                SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();
                aAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connString.Close();
            }
        }
        public void UpdatePatient(string PATIENT_ID, string FNAME, string MIDINIT, string LNAME, string GENDER, string STREET, string CITY, string PATIENT_STATE, decimal ZIP, DateTime DOB, string HOME_PHONE, string CELL_PHONE, string EMAIL_I, string EMAIL_II, string EMAIL_III)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "UPDATEPATIENT";
                    withBlock.Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID);
                    withBlock.Parameters.AddWithValue("@FNAME", FNAME);
                    withBlock.Parameters.AddWithValue("@MIDINIT", MIDINIT);
                    withBlock.Parameters.AddWithValue("@LNAME", LNAME);
                    withBlock.Parameters.AddWithValue("@GENDER", GENDER);
                    withBlock.Parameters.AddWithValue("@STREET", STREET);
                    withBlock.Parameters.AddWithValue("@CITY", CITY);
                    withBlock.Parameters.AddWithValue("@PATIENT_STATE", PATIENT_STATE);
                    withBlock.Parameters.AddWithValue("@ZIP", ZIP);
                    withBlock.Parameters.AddWithValue("@DOB", DOB);
                    withBlock.Parameters.AddWithValue("@HOME_PHONE", HOME_PHONE);
                    withBlock.Parameters.AddWithValue("@CELL_PHONE", CELL_PHONE);
                    withBlock.Parameters.AddWithValue("@EMAIL_I", EMAIL_I);
                    withBlock.Parameters.AddWithValue("@EMAIL_II", EMAIL_II);
                    withBlock.Parameters.AddWithValue("@EMAIL_III", EMAIL_III);
                    withBlock.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            connString.Close();
        }
        public void DBConnection(string ProcedureType)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = ProcedureType;
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void AddPatient(string PATIENT_ID, string FNAME, string MIDINIT, string LNAME, string GENDER, string STREET, string CITY, string PATIENT_STATE, decimal ZIP, DateTime DOB, string HOME_PHONE, string CELL_PHONE, string EMAIL_I, string EMAIL_II, string EMAIL_III)
        {
            try
            {
                string ProcedureType = "ADDPATIENT";
                DBConnection(ProcedureType);
                {
                    var withBlock = cmdString;
                    withBlock.Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID);
                    withBlock.Parameters.AddWithValue("@FNAME", FNAME);
                    withBlock.Parameters.AddWithValue("@MIDINIT", MIDINIT);
                    withBlock.Parameters.AddWithValue("@LNAME", LNAME);
                    withBlock.Parameters.AddWithValue("@GENDER", GENDER);
                    withBlock.Parameters.AddWithValue("@STREET", STREET);
                    withBlock.Parameters.AddWithValue("@CITY", CITY);
                    withBlock.Parameters.AddWithValue("@PATIENT_STATE", PATIENT_STATE);
                    withBlock.Parameters.AddWithValue("@ZIP", ZIP);
                    withBlock.Parameters.AddWithValue("@DOB", DOB);
                    withBlock.Parameters.AddWithValue("@HOME_PHONE", HOME_PHONE);
                    withBlock.Parameters.AddWithValue("@CELL_PHONE", CELL_PHONE);
                    withBlock.Parameters.AddWithValue("@EMAIL_I", EMAIL_I);
                    withBlock.Parameters.AddWithValue("@EMAIL_II", EMAIL_II);
                    withBlock.Parameters.AddWithValue("@EMAIL_III", EMAIL_III);
                    withBlock.ExecuteNonQuery();
                }
                Reply2 = "Success";
            }
            catch (Exception ex)
            {
                Reply = ex.ToString();
                Reply2 = "Fail";
            }
            connString.Close();
        }
        public void SearchPatients(string PATIENT_ID, string FNAME, string LNAME, string GENDER)
        {
            try
            {
                // Dim dateDOB As Date = Date.Parse(DOB)
                string ProcedureType = "SEARCHPATIENTS";
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "SEARCHPATIENTS";
                }
                // DBConnection(ProcedureType)
                {
                    var withBlock = cmdString;
                    withBlock.Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID);
                    withBlock.Parameters.AddWithValue("@FNAME", FNAME);
                    withBlock.Parameters.AddWithValue("@LNAME", LNAME);
                    withBlock.Parameters.AddWithValue("@GENDER", GENDER);
                }
                SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();
                aAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            connString.Close();
        }
        public void SearchPrescriptions(string PRESCRIPTION_ID, string MEDICATION_NAME, string PHYSICIAN_ID, string PATIENT_ID)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "SEARCHPRESCRIPTIONS";
                }
                // DBConnection(ProcedureType)
                {
                    var withBlock = cmdString;
                    withBlock.Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID);
                    withBlock.Parameters.AddWithValue("@PRESCRIPTION_ID", PRESCRIPTION_ID);
                    withBlock.Parameters.AddWithValue("@MEDICATION_NAME", MEDICATION_NAME);
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID);
                }
                SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();
                aAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            connString.Close();
        }
        public void SearchPhysicians(string PHYSICIAN_ID, string FNAME, string LNAME, string GENDER, string OFFICE_PHONE, string WORK_EMAIL, string POSITION, string SPECIALTY)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "SEARCHPHYSICIANS";
                }
                // DBConnection(ProcedureType)
                {
                    var withBlock = cmdString;
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID);
                    withBlock.Parameters.AddWithValue("@FNAME", FNAME);
                    withBlock.Parameters.AddWithValue("@LNAME", LNAME);
                    withBlock.Parameters.AddWithValue("@GENDER", GENDER);
                    withBlock.Parameters.AddWithValue("@OFFICE_PHONE", OFFICE_PHONE);
                    withBlock.Parameters.AddWithValue("@WORK_EMAIL", WORK_EMAIL);
                    withBlock.Parameters.AddWithValue("@POSITION", POSITION);
                    withBlock.Parameters.AddWithValue("@SPECIALTY", SPECIALTY);
                }
                SqlClient.SqlDataAdapter aAdapter = new SqlClient.SqlDataAdapter();
                aAdapter.SelectCommand = cmdString;
                DataSet aDataSet = new DataSet();
                aAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            connString.Close();
        }
        public void CheckEmptyTextBoxes(TextBox input, string output)
        {
            try
            {
                if ((string.IsNullOrEmpty(input.Text)))
                    strResult = "Fail";
                else
                    strResult = "Success";
            }
            catch (Exception ex)
            {
            }
        }
        public string Decrypt(string stringToDecrypt, string sEncryptionKey)
        {
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(Strings.Left(sEncryptionKey, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string Encrypt(string stringToEncrypt, string SEncryptionKey)
        {
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(Strings.Left(SEncryptionKey, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public void DeleteProcedure(string RECORD_ID, string RecordType)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                switch (RecordType)
                {
                    case "PATIENT":
                        {
                            {
                                var withBlock = cmdString;
                                withBlock.Connection = connString;
                                withBlock.CommandType = CommandType.StoredProcedure;
                                withBlock.CommandTimeout = 900;
                                withBlock.CommandText = "DELETEPRESCRIPTIONBYPATIENT";
                                withBlock.Parameters.AddWithValue("@PATIENT_ID", RECORD_ID);
                                withBlock.ExecuteNonQuery();

                                withBlock.Parameters.Clear();
                                withBlock.Connection = connString;
                                withBlock.CommandType = CommandType.StoredProcedure;
                                withBlock.CommandTimeout = 900;
                                withBlock.CommandText = "DELETEPATIENT";
                                withBlock.Parameters.AddWithValue("@PATIENT_ID", RECORD_ID);
                                withBlock.ExecuteNonQuery();
                            }

                            break;
                        }

                    case "PHYSICIAN":
                        {
                            {
                                var withBlock = cmdString;
                                withBlock.Connection = connString;
                                withBlock.CommandType = CommandType.StoredProcedure;
                                withBlock.CommandTimeout = 900;
                                withBlock.CommandText = "DELETEPRESCRIPTIONBYPHYSICIAN";
                                withBlock.Parameters.AddWithValue("@PHYSICIAN_ID", RECORD_ID);
                                withBlock.ExecuteNonQuery();

                                withBlock.Parameters.Clear();
                                withBlock.Connection = connString;
                                withBlock.CommandType = CommandType.StoredProcedure;
                                withBlock.CommandTimeout = 900;
                                withBlock.CommandText = "DELETEPHYSICIAN";
                                withBlock.Parameters.AddWithValue("@PHYSICIAN_ID", RECORD_ID);
                                withBlock.ExecuteNonQuery();
                            }

                            break;
                        }

                    case "PRESCRIPTION":
                        {
                            {
                                var withBlock = cmdString;
                                withBlock.Connection = connString;
                                withBlock.CommandType = CommandType.StoredProcedure;
                                withBlock.CommandTimeout = 900;
                                withBlock.CommandText = "DELETEPRESCRIPTION";
                                withBlock.Parameters.AddWithValue("@PRESCRIPTION_ID", RECORD_ID);
                                withBlock.ExecuteNonQuery();
                            }

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
            }
            connString.Close();
        }

        // Uses the stored procedure ADDPHYSICIAN to add a physician record from frmAddRecordPhysician
        public void AddPhysician(string PHYSICIAN_ID, string FNAME, string MIDINIT, string LNAME, string GENDER, string STREET, string CITY, string PHYSICIAN_STATE, decimal ZIP, DateTime DOB, string OFFICE_PHONE, string PERSONAL_PHONE, string WORK_EMAIL, string EMAIL_I, string EMAIL_II, string POSITION, string SPECIALTY, decimal SALARY)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "ADDPHYSICIAN";
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID);
                    withBlock.Parameters.AddWithValue("@FNAME", FNAME);
                    withBlock.Parameters.AddWithValue("@MIDINIT", MIDINIT);
                    withBlock.Parameters.AddWithValue("@LNAME", LNAME);
                    withBlock.Parameters.AddWithValue("@GENDER", GENDER);
                    withBlock.Parameters.AddWithValue("@STREET", STREET);
                    withBlock.Parameters.AddWithValue("@CITY", CITY);
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_STATE", PHYSICIAN_STATE);
                    withBlock.Parameters.AddWithValue("@ZIP", ZIP);
                    withBlock.Parameters.AddWithValue("@DOB", DOB);
                    withBlock.Parameters.AddWithValue("@OFFICE_PHONE", OFFICE_PHONE);
                    withBlock.Parameters.AddWithValue("@PERSONAL_PHONE", PERSONAL_PHONE);
                    withBlock.Parameters.AddWithValue("@WORK_EMAIL", WORK_EMAIL);
                    withBlock.Parameters.AddWithValue("@EMAIL_I", EMAIL_I);
                    withBlock.Parameters.AddWithValue("@EMAIL_II", EMAIL_II);
                    withBlock.Parameters.AddWithValue("@POSITION", POSITION);
                    withBlock.Parameters.AddWithValue("@SPECIALTY", SPECIALTY);
                    withBlock.Parameters.AddWithValue("@SALARY", SALARY);
                    withBlock.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            connString.Close();
        }
        // Uses the stored procedure ADDPRESCRIPTION to add a prescription record from frmAddRecordPrescription
        public void AddPrescription(string PRESCRIPTION_ID, string MEDICATION_NAME, decimal REFILL_AMT, DateTime REFILL_DATE, string DOSAGE, string INTAKE_METHOD, string FREQUENCY, string PHYSICIAN_ID, string PATIENT_ID)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "ADDPRESCRIPTION";
                    withBlock.Parameters.AddWithValue("@PRESCRIPTION_ID", PRESCRIPTION_ID);
                    withBlock.Parameters.AddWithValue("@MEDICATION_NAME", MEDICATION_NAME);
                    withBlock.Parameters.AddWithValue("@REFILL_AMT", REFILL_AMT);
                    withBlock.Parameters.AddWithValue("@REFILL_DATE", REFILL_DATE);
                    withBlock.Parameters.AddWithValue("@DOSAGE", DOSAGE);
                    withBlock.Parameters.AddWithValue("@INTAKE_METHOD", INTAKE_METHOD);
                    withBlock.Parameters.AddWithValue("@FREQUENCY", FREQUENCY);
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID);
                    withBlock.Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID);
                    withBlock.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            connString.Close();
        }
        public void UpdateRecord(string StoredProcedure)
        {
            cmdString.Parameters.Clear();
            connString.Open();
            {
                var withBlock = cmdString;
                withBlock.Connection = connString;
                withBlock.CommandType = CommandType.StoredProcedure;
                withBlock.CommandTimeout = 900;
                withBlock.CommandText = StoredProcedure;
            }
            aAdapter.SelectCommand = cmdString;
            aAdapter.Fill(aDataSet);
            // If aDataSet.Tables(0).Rows.Count > 0 Then
            // frmUpdateRecord.dgvRecordIDTest.DataSource = aDataSet.Tables(0)
            // End If
            connString.Close();
        }
        // Fills the patient/doctor ID comboboxes on frmAddRecordPrescription
        public void AddPartiesPrescription(string Procedure, string DGVOutput)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = Procedure;
                }
                aAdapter.SelectCommand = cmdString;
                aAdapter.Fill(aDataSet);
                if ((aDataSet.Tables(0).Rows.Count > 0))
                {
                    switch (DGVOutput)
                    {
                        case "dgvRecordIDTest":
                            {
                                break;
                            }

                        case "dgvRecordIDTest2":
                            {
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            connString.Close();
        }
        public void AddPrescription()
        {
            cmdString.Parameters.Clear();
            connString.Open();
            {
                var withBlock = cmdString;
                withBlock.Connection = connString;
                withBlock.CommandType = CommandType.StoredProcedure;
                withBlock.CommandTimeout = 900;
                withBlock.CommandText = "VIEWPRESCRIPTIONS";
            }
            aAdapter.SelectCommand = cmdString;
            aAdapter.Fill(aDataSet);
            if (aDataSet.Tables(0).Rows.Count > 0)
            {
            }
            connString.Close();
        }
        public DataSet FillUpdateForms(string Record_ID, string StoredProcedure, string DataBaseColumn)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                cmdString.Connection = connString;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = StoredProcedure;
                cmdString.Parameters.AddWithValue(DataBaseColumn, Record_ID);
                aAdapter.SelectCommand = cmdString;
                aAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connString.Close();
            }
        }
        public DataSet ViewPrescription(string PRESCRIPTION_ID)
        {
            try
            {
                connString.Open();
                cmdString.Connection = connString;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "CHECKPRESCRIPTION";
                cmdString.Parameters.AddWithValue("@PRESCRIPTION_ID", PRESCRIPTION_ID);
                aAdapter.SelectCommand = cmdString;
                aAdapter.Fill(aDataSet);
                return aDataSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            connString.Close();
        }
        public void CheckUpdateNulls(TextBox FormObject, string Output)
        {
            if ((FormObject.Text == "N/A"))
            {
                FormObject.Text = "";
                // Return that there are empty textboxes
                Reply = "Fail";
                return;
            }
        }
        public void UpdatePhysician(string PHYSICIAN_ID, string FNAME, string MIDINIT, string LNAME, string GENDER, string STREET, string CITY, string PHYSICIAN_STATE, decimal ZIP, DateTime DOB, string OFFICE_PHONE, string PERSONAL_PHONE, string WORK_EMAIL, string EMAIL_I, string EMAIL_II, string POSITION, string SPECIALTY, decimal SALARY)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();

                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "UPDATEPHYSICIAN";
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID);
                    withBlock.Parameters.AddWithValue("@FNAME", FNAME);
                    withBlock.Parameters.AddWithValue("@MIDINIT", MIDINIT);
                    withBlock.Parameters.AddWithValue("@LNAME", LNAME);
                    withBlock.Parameters.AddWithValue("@GENDER", GENDER);
                    withBlock.Parameters.AddWithValue("@STREET", STREET);
                    withBlock.Parameters.AddWithValue("@CITY", CITY);
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_STATE", PHYSICIAN_STATE);
                    withBlock.Parameters.AddWithValue("@ZIP", ZIP);
                    withBlock.Parameters.AddWithValue("@DOB", DOB);
                    withBlock.Parameters.AddWithValue("@OFFICE_PHONE", OFFICE_PHONE);
                    withBlock.Parameters.AddWithValue("@PERSONAL_PHONE", PERSONAL_PHONE);
                    withBlock.Parameters.AddWithValue("@WORK_EMAIL", WORK_EMAIL);
                    withBlock.Parameters.AddWithValue("@EMAIL_I", EMAIL_I);
                    withBlock.Parameters.AddWithValue("@EMAIL_II", EMAIL_II);
                    withBlock.Parameters.AddWithValue("@POSITION", POSITION);
                    withBlock.Parameters.AddWithValue("@SPECIALTY", SPECIALTY);
                    withBlock.Parameters.AddWithValue("@SALARY", SALARY);
                    withBlock.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            connString.Close();
        }
        public void UpdatePhysician(string PHYSICIAN_ID, string FNAME, string MIDINIT, string LNAME, string GENDER, string STREET, string CITY, string PHYSICIAN_STATE, decimal ZIP, DateTime DOB, string OFFICE_PHONE, string PERSONAL_PHONE, string WORK_EMAIL, string EMAIL_I, string EMAIL_II, string POSITION, string SPECIALTY, decimal SALARY)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();

                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "UPDATEPHYSICIAN";
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID);
                    withBlock.Parameters.AddWithValue("@FNAME", FNAME);
                    withBlock.Parameters.AddWithValue("@MIDINIT", MIDINIT);
                    withBlock.Parameters.AddWithValue("@LNAME", LNAME);
                    withBlock.Parameters.AddWithValue("@GENDER", GENDER);
                    withBlock.Parameters.AddWithValue("@STREET", STREET);
                    withBlock.Parameters.AddWithValue("@CITY", CITY);
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_STATE", PHYSICIAN_STATE);
                    withBlock.Parameters.AddWithValue("@ZIP", ZIP);
                    withBlock.Parameters.AddWithValue("@DOB", DOB);
                    withBlock.Parameters.AddWithValue("@OFFICE_PHONE", OFFICE_PHONE);
                    withBlock.Parameters.AddWithValue("@PERSONAL_PHONE", PERSONAL_PHONE);
                    withBlock.Parameters.AddWithValue("@WORK_EMAIL", WORK_EMAIL);
                    withBlock.Parameters.AddWithValue("@EMAIL_I", EMAIL_I);
                    withBlock.Parameters.AddWithValue("@EMAIL_II", EMAIL_II);
                    withBlock.Parameters.AddWithValue("@POSITION", POSITION);
                    withBlock.Parameters.AddWithValue("@SPECIALTY", SPECIALTY);
                    withBlock.Parameters.AddWithValue("@SALARY", SALARY);
                    withBlock.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            connString.Close();
        }
        public void UpdatePrescription(string PRESCRIPTION_ID, string MEDICATION_NAME, decimal REFILL_AMT, DateTime REFILL_DATE, string DOSAGE, string INTAKE_METHOD, string FREQUENCY, string PHYSICIAN_ID, string PATIENT_ID)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "UPDATEPRESCRIPTION";
                    withBlock.Parameters.AddWithValue("@PRESCRIPTION_ID", PRESCRIPTION_ID);
                    withBlock.Parameters.AddWithValue("@MEDICATION_NAME", MEDICATION_NAME);
                    withBlock.Parameters.AddWithValue("@REFILL_AMT", REFILL_AMT);
                    withBlock.Parameters.AddWithValue("REFILL_DATE", REFILL_DATE);
                    withBlock.Parameters.AddWithValue("@DOSAGE", DOSAGE);
                    withBlock.Parameters.AddWithValue("@INTAKE_METHOD", INTAKE_METHOD);
                    withBlock.Parameters.AddWithValue("@FREQUENCY", FREQUENCY);
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID);
                    withBlock.Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID);
                    withBlock.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            connString.Close();
        }
        public void AddDropRefills(string PRESCRIPTION_ID, decimal REFILL_AMT, DateTime REFILL_DATE, string StoredProcedure)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = StoredProcedure;
                    withBlock.Parameters.AddWithValue("@PRESCRIPTION_ID", PRESCRIPTION_ID);
                    withBlock.Parameters.AddWithValue("@REFILL_AMT", REFILL_AMT);
                    withBlock.Parameters.AddWithValue("@REFILL_DATE", REFILL_DATE);
                    withBlock.ExecuteNonQuery();
                }
                Reply = "True";
            }
            catch (Exception ex)
            {
                Reply = ex.ToString();
            }
            connString.Close();
        }

        public void ViewRecordID(string StoredProcedure)
        {
            cmdString.Parameters.Clear();
            connString.Open();
            {
                var withBlock = cmdString;
                withBlock.Connection = connString;
                withBlock.CommandType = CommandType.StoredProcedure;
                withBlock.CommandTimeout = 900;
                withBlock.CommandText = StoredProcedure;
            }
            aAdapter.SelectCommand = cmdString;
            aAdapter.Fill(aDataSet);
            connString.Close();
        }
        public void ViewPrescription()
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "VIEWPRESCRIPTIONS";
                }
                aAdapter.SelectCommand = cmdString;
                aAdapter.Fill(aDataSet);
            }
            catch (Exception ex)
            {
                Reply = ex.ToString();
            }
            return aDataSet;
            connString.Close();
        }
        public void GetPrescriptionByID(object prescriptionID)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "CHECKPRESCRIPTION";
                    withBlock.Parameters.AddWithValue("@PRESCRIPTION_ID", prescriptionID);
                }
                aAdapter.SelectCommand = cmdString;
                aAdapter.Fill(aDataSet);
            }
            catch (Exception ex)
            {
            }
            connString.Close();
            return aDataSet;
        }
        public void ViewPrescriptionByPatient(string PATIENT_ID)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "CHECKPRESCRIPTIONSBYPATIENT";
                    withBlock.Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID);
                }
                aAdapter.SelectCommand = cmdString;
                aAdapter.Fill(aDataSet);
                if (aDataSet.Tables(0).Rows.Count > 0)
                {
                }
            }
            catch (Exception ex)
            {
            }
            connString.Close();
        }
        public void ViewPhysician(string PHYSICIAN_ID)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "CHECKPHYSICIANS";
                    withBlock.Parameters.AddWithValue("@PHYSICIAN_ID", PHYSICIAN_ID);
                }
                aAdapter.SelectCommand = cmdString;
                aAdapter.Fill(aDataSet);
                if (aDataSet.Tables(0).Rows.Count > 0)
                {
                }
            }
            catch (Exception ex)
            {
            }
            connString.Close();
        }
        public void ViewPatient(string PATIENT_ID)
        {
            try
            {
                cmdString.Parameters.Clear();
                connString.Open();
                {
                    var withBlock = cmdString;
                    withBlock.Connection = connString;
                    withBlock.CommandType = CommandType.StoredProcedure;
                    withBlock.CommandTimeout = 900;
                    withBlock.CommandText = "CHECKPATIENTS";
                    withBlock.Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID);
                }
                aAdapter.SelectCommand = cmdString;
                aAdapter.Fill(aDataSet);
                if (aDataSet.Tables(0).Rows.Count > 0)
                {
                }
            }
            catch (Exception ex)
            {
            }
            connString.Close();
        }
    }



}