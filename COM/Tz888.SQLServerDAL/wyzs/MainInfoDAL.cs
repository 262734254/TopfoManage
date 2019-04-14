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
    /// 主表
    /// </summary>
    public class MainInfoDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="MainInfo"></param>
        /// <returns></returns>
        public bool Add(MainInfoTab MainInfo,DetailTab Detail)
        {
            SqlParameter[] Paras = new SqlParameter[] {                
                //--主表信息
                //@Title varchar(200),--标题
                new SqlParameter("@Title",SqlDbType.VarChar,200),
                //@MemberId varchar(50),--会员ID
                new SqlParameter("@MemberId",SqlDbType.VarChar,50),
                //@Types int,--标志(1->求租HireTab 2->购买BuyTab 3->出租LettingTab 4->出售SaleTab)
                new SqlParameter("@Types",SqlDbType.Int),
                //@State int,--状态(1->可用,2->不可用)
                new SqlParameter("@State",SqlDbType.Int),
                //@Htmlurl varchar(200),--静态页面地址
                new SqlParameter("@Htmlurl",SqlDbType.VarChar,200),
                //@PublishTime dateTime,--发布时间
                //new SqlParameter("@PublishTime",SqlDbType.DateTime),
                
                //--子表信息
                //@TelePhone varchar(50),--联系电话
                new SqlParameter("@TelePhone",SqlDbType.VarChar,50),
                //@Email varchar(50),--邮箱
                new SqlParameter("@Email",SqlDbType.VarChar,50),
                //@LinkMan varchar(50),--联系人
                new SqlParameter("@LinkMan",SqlDbType.VarChar,50),
                //@Source int,--来源(1->业主,2->需求)
                new SqlParameter("@Source",SqlDbType.Int),
                //@Purpose int,--用途(1->门面,2->办公,3->商住两用)
                new SqlParameter("@Purpose",SqlDbType.Int),
                //@Floor int,--楼层(1->1-5楼,2->5-8楼,3->8楼以上)
                new SqlParameter("@Floor",SqlDbType.Int),
                //@Hire int,--租金(1->40-60元/平方米,2->60-80元/平方米,3->80元以上)
                new SqlParameter("@Hire",SqlDbType.Int),
                //@Fitment int,--面积(1->100平米以内,2->100-200平米,3->200平米以上)
                new SqlParameter("@Area",SqlDbType.Int),
                //@Elevator int--装修(1->简装,2->无,3->豪装)
                new SqlParameter("@Fitment",SqlDbType.Int),
                //电梯(1->有,2->无)
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
        /// 修改
        /// </summary>
        /// <param name="MainInfo"></param>
        /// <returns></returns>
        public bool Modify(MainInfoTab MainInfo,DetailTab Detail)
        {
            SqlParameter[] Paras = new SqlParameter[] { 
                //--主表信息
                //@Title varchar(200),--标题
                new SqlParameter("@Title",SqlDbType.VarChar,200),
                //@MemberId varchar(50),--会员ID
                new SqlParameter("@MemberId",SqlDbType.VarChar,50),
                //@Types int,--标志(1->求租HireTab 2->购买BuyTab 3->出租LettingTab 4->出售SaleTab)
                new SqlParameter("@Types",SqlDbType.Int),
                //@State int,--状态(1->可用,2->不可用)
                new SqlParameter("@State",SqlDbType.Int),
                //@Htmlurl varchar(200),--静态页面地址
                new SqlParameter("@Htmlurl",SqlDbType.VarChar,200),
                //@PublishTime dateTime,--发布时间
                //new SqlParameter("@PublishTime",SqlDbType.DateTime),
                
                //--子表信息
                //@TelePhone varchar(50),--联系电话
                new SqlParameter("@TelePhone",SqlDbType.VarChar,50),
                //@Email varchar(50),--邮箱
                new SqlParameter("@Email",SqlDbType.VarChar,50),
                //@LinkMan varchar(50),--联系人
                new SqlParameter("@LinkMan",SqlDbType.VarChar,50),
                //@Source int,--来源
                new SqlParameter("@Source",SqlDbType.Int),
                //@Purpose int,--用途(1->门面,2->办公,3->商住两用)
                new SqlParameter("@Purpose",SqlDbType.Int),
                //@Floor int,--楼层(1->1-5楼,2->5-8楼,3->8楼以上)
                new SqlParameter("@Floor",SqlDbType.Int),
                //@Hire int,--租金(1->40-60元/平方米,2->60-80元/平方米,3->80元以上)
                new SqlParameter("@Hire",SqlDbType.Int),
                 //@Fitment int,--面积(1->100平米以内,2->100-200平米,3->200平米以上)
                new SqlParameter("@Area",SqlDbType.Int),
                //@Elevator int--装修(1->简装,2->无,3->豪装)
                new SqlParameter("@Fitment",SqlDbType.Int),
                //电梯(1->有,2->无)
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
        /// 删除
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        public bool Delete(string MainId)
        {
            SqlParameter[] Paras = new SqlParameter[] { 
                //--主表信息
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
        /// 获取详情
        /// </summary>
        /// <returns></returns>
        public DataSet GetDetailById(string MainId)
        {
            SqlParameter[] Paras = new SqlParameter[] { 
                //--主表信息
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

