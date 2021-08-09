namespace OCBCDemo.Business.DataAccess
{
    using OCBCDemo.Business.Common;
    using OCBCDemo.Business.Common.Utility;
    using OCBCDemo.Business.Common.Utility.Pagination;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    public class TransactionDataAccess
    {
        Logger _logger = new Logger(typeof(TransactionDataAccess));
        public string Transfer(Guid accountId, string recipientEmail, decimal transferAmount)
        {
            try
            {
                var result = "";
                using (SqlConnection conn = new SqlConnection(SqlHelper.constr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("AddTransactionInfo"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@SenderId", accountId);
                        cmd.Parameters.AddWithValue("@RecipientEmail", recipientEmail);
                        cmd.Parameters.AddWithValue("@TransferAmount", transferAmount);

                        result = (string)cmd.ExecuteScalar();
                    }
                    conn.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error Occurred on {DateTime.Now} when transfer, Error message: {ex.Message} ");
                return "Error occurred when transfer, please contact with administrator";
            }
        }

        public string Deposit(Guid accountId, decimal amount)
        {
            try
            {
                var result = "";
                using (SqlConnection conn = new SqlConnection(SqlHelper.constr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateBalance"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;

                        cmd.Parameters.AddWithValue("@Id", accountId);
                        cmd.Parameters.AddWithValue("@Amount", amount);

                        result = (string)cmd.ExecuteScalar();
                    }
                    conn.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error Occurred on {DateTime.Now} when deposit, Error message: {ex.Message} ");
                return "Error occurred when deposit, please contact with administrator";
            }
        }

    }
}
