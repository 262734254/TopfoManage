//============================================================
// Producnt name:		ExamSystem
// Version: 			1.0
// Coded by:			Eagle Lifeng
// Auto generated at: 	2011-3-17 14:16:51
//============================================================

using System;

namespace GZS.Model.news
{
    [Serializable]
    public class NewsTypeTab
    {
       	/// <summary>
		/// 
		/// </summary>
        private int _typeID;
        //[DataField("TypeID")]
        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }
        


        private string _typeName;
        //[DataField("TypeName")]
      	/// <summary>
		/// 
		/// </summary>
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }
        private int boolStar;

        public int BoolStar
        {
            get { return boolStar; }
            set { boolStar = value; }
        }
        private int _outid;

        public int Outid
        {
            get { return _outid; }
            set { _outid = value; }
        }
    }
}
