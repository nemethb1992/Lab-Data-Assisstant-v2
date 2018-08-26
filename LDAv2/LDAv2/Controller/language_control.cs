using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LDAv2.Model.language_model;

namespace LDAv2.Controller
{
    class language_control
    {
        private static int LanguageIDs;
        public int LanguageID { get { return LanguageIDs; } set { LanguageIDs = value; } }

        private List<Language_Struct> WordLists;
        public List<Language_Struct> WordList { get { return WordLists; } set { WordLists = value; } }

        dbEntities dbE = new dbEntities();

        public language_control()
        {
            WordList = dbE.Language_Query_MySQL("select * from language");
        }

        public string Word(int id)
        {
            switch (LanguageID)
            {
                case 1:
                    {
                        return WordList[id].hu_HU;
                    }
                case 2:
                    {
                        return WordList[id].de_DE;
                    }
                case 3:
                    {
                        return WordList[id].en_EN;
                    }
                default:
                    {
                        return WordList[id].hu_HU;
                    }
            }
        }

    }

}
