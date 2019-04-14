using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;
using Tz888.Model.wyzs;

namespace Tz888.SQLServerDAL.wyzs
{
    /// <summary>
    /// ����
    /// </summary>
    public class MainInfoDAL
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="MainInfo"></param>
        /// <returns></returns>
        public bool Add(MainInfoTab MainInfo,DetailTab Detail)
        {
            SqlParameter[] Paras = new SqlParameter[] {                
                //--������Ϣ
                //@Title varchar(200),--����
                new SqlParameter("@Title",SqlDbType.VarChar,200),
                //@MemberId varchar(50),--��ԱID
                new SqlParameter("@MemberId",SqlDbType.VarChar,50),
                //@Types int,--��־(1->����HireTab 2->����BuyTab 3->����LettingTab 4->����SaleTab)
                new SqlParameter("@Types",SqlDbType.Int),
                //@State int,--״̬(1->����,2->������)
                new SqlParameter("@State",SqlDbType.Int),
                //@Htmlurl varchar(200),--��̬ҳ���ַ
                new SqlParameter("@Htmlurl",SqlDbType.VarChar,200),
                //@PublishTime dateTime,--����ʱ��
                //new SqlParameter("@PublishTime",SqlDbType.DateTime),
                
                //--�ӱ���Ϣ
                //@TelePhone varchar(50),--��ϵ�绰
                new SqlParameter("@TelePhone",SqlDbType.VarChar,50),
                //@Email varchar(50),--����
                new SqlParameter("@Email",SqlDbType.VarChar,50),
                //@LinkMan varchar(50),--��ϵ��
                new SqlParameter("@LinkMan",SqlDbType.VarChar,50),
                //@Source int,--��Դ(1->ҵ��,2->����)
                new SqlParameter("@Source",SqlDbType.Int),
                //@Purpose int,--��;(1->����,2->�칫,3->��ס����)
                new SqlParameter("@Purpose",SqlDbType.Int),
                //@Floor int,--¥��(1->1-5¥,2->5-8¥,3->8¥����)
                new SqlParameter("@Floor",SqlDbType.Int),
                //@Hire int,--���(1->40-60Ԫ/ƽ����,2->60-80Ԫ/ƽ����,3->80Ԫ����)
                new SqlParameter("@Hire",SqlDbType.Int),
                //@Fitment int,--���(1->100ƽ������,2->100-200ƽ��,3->200ƽ������)
                new SqlParameter("@Area",SqlDbType.Int),
                //@Elevator int--װ��(1->��װ,2->��,3->��װ)
                new SqlParameter("@Fitment",SqlDbType.Int),
                //����(1->��,2->��)
                new SqlParameter("@Elevator",SqlDbType.Int)
            };
            Paras[0].Value=MainInfo.Title;
            Paras[1].Value=MainInfo.MemberId;
            Paras[2].Value=MainInfo.Types;
            Paras[3].Value=MainInfo.State;
            Paras[4].Value=MainInfo.Htmlurl;
            //Paras[5].Value=MainInfo.PublishTime;

            Paras[5].Value=Detail.TelePhone;
            Paras[6].Value=Detail.Email;
            Paras[7].Value=Detail.LinkMan;
            Paras[8].Value=Detail.Source;
            Paras[9].Value=Detail.Purpose;
            Paras[10].Value=Detail.Floor;
            Paras[11].Value=Detail.Hire;
            Paras[12].Value = Detail.Area;
            Paras[13].Value = Detail.Fitment;
            Paras[14].Value = Detail.Elevator;

            int row = DBHelper.ExecuteNonQueryProc("ProAdd", Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="MainInfo"></param>
        /// <returns></returns>
        public bool Modify(MainInfoTab MainInfo,DetailTab Detail)
        {
            SqlParameter[] Paras = new SqlParameter[] { 
                //--������Ϣ
                //@Title varchar(200),--����
                new SqlParameter("@Title",SqlDbType.VarChar,200),
                //@MemberId varchar(50),--��ԱID
                new SqlParameter("@MemberId",SqlDbType.VarChar,50),
                //@Types int,--��־(1->����HireTab 2->����BuyTab 3->����LettingTab 4->����SaleTab)
                new SqlParameter("@Types",SqlDbType.Int),
                //@State int,--״̬(1->����,2->������)
                new SqlParameter("@State",SqlDbType.Int),
                //@Htmlurl varchar(200),--��̬ҳ���ַ
                new SqlParameter("@Htmlurl",SqlDbType.VarChar,200),
                //@PublishTime dateTime,--����ʱ��
                //new SqlParameter("@PublishTime",SqlDbType.DateTime),
                
                //--�ӱ���Ϣ
                //@TelePhone varchar(50),--��ϵ�绰
                new SqlParameter("@TelePhone",SqlDbType.VarChar,50),
                //@Email varchar(50),--����
                new SqlParameter("@Email",SqlDbType.VarChar,50),
                //@LinkMan varchar(50),--��ϵ��
                new SqlParameter("@LinkMan",SqlDbType.VarChar,50),
                //@Source int,--��Դ
                new SqlParameter("@Source",SqlDbType.Int),
                //@Purpose int,--��;(1->����,2->�칫,3->��ס����)
                new SqlParameter("@Purpose",SqlDbType.Int),
                //@Floor int,--¥��(1->1-5¥,2->5-8¥,3->8¥����)
                new SqlParameter("@Floor",SqlDbType.Int),
                //@Hire int,--���(1->40-60Ԫ/ƽ����,2->60-80Ԫ/ƽ����,3->80Ԫ����)
                new SqlParameter("@Hire",SqlDbType.Int),
                 //@Fitment int,--���(1->100ƽ������,2->100-200ƽ��,3->200ƽ������)
                new SqlParameter("@Area",SqlDbType.Int),
                //@Elevator int--װ��(1->��װ,2->��,3->��װ)
                new SqlParameter("@Fitment",SqlDbType.Int),
                //����(1->��,2->��)
                new SqlParameter("@Elevator",SqlDbType.Int),
                //MainId
                new SqlParameter("@MainId",SqlDbType.Int)
            };
            Paras[0].Value = MainInfo.Title;
            Paras[1].Value = MainInfo.MemberId;
            Paras[2].Value = MainInfo.Types;
            Paras[3].Value = MainInfo.State;
            Paras[4].Value = MainInfo.Htmlurl;
            //Paras[5].Value = MainInfo.PublishTime;

            Paras[5].Value = Detail.TelePhone;
            Paras[6].Value = Detail.Email;
            Paras[7].Value = Detail.LinkMan;
            Paras[8].Value = Detail.Source;
            Paras[9].Value = Detail.Purpose;
            Paras[10].Value = Detail.Floor;
            Paras[11].Value = Detail.Hire;
            Paras[12].Value = Detail.Area;
            Paras[13].Value = Detail.Fitment;
            Paras[14].Value = Detail.Elevator;
            Paras[15].Value = MainInfo.Id;

            int row = DBHelper.ExecuteNonQueryProc("ProModify", Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        public bool Delete(string MainId)
        {
            SqlParameter[] Paras = new SqlParameter[] { 
                //--������Ϣ
                new SqlParameter("@MainId",SqlDbType.VarChar,200)
            };
            Paras[0].Value = MainId;
            int row = DBHelper.ExecuteNonQueryProc("ProDelete", Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        public DataSet GetDetailById(string MainId)
        {
            SqlParameter[] Paras = new SqlParameter[] { 
                //--������Ϣ
                new SqlParameter("@MainId",SqlDbType.VarChar,200)
            };
            Paras[0].Value = MainId;
            return DBHelper.RunProcedureT("GetDetail", Paras, "TempTable");
        }

        public DataTable GetTradeShowList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
                                            new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
                                            new SqlParameter("@Key",SqlDbType.VarChar,50),
                                            new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
                                            new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
                                            new SqlParameter("@Sort",SqlDbType.VarChar,255),
                                            new SqlParameter("@Page",SqlDbType.BigInt),
                                            new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
                                            new SqlParameter("@TotalCount",SqlDbType.BigInt)
                                        };

            parameters[0].Value = ObjectName;
            parameters[1].Value = Key;
            parameters[2].Value = ShowFiled;
            parameters[3].Value = Where;
            parameters[4].Value = OrderFiled;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = PageCurrent;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;

            DataSet ds = DBHelper.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables["ds"];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt32(parameters[7].Value);
                    PageCurrent = Convert.ToInt32(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt32(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        PageCurrent = 1;
                    }
                    else
                    {
                        PageCurrent = 0;
                    }
                }
            }
            return dt;
        }
    }
}

