using LDAv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAv2.Controller
{
    class Language
    {
        private static int LanguageIDs;
        public int LanguageID { get { return LanguageIDs; } set { LanguageIDs = value; } }

        private List<LanguageModel> WordLists;
        public List<LanguageModel> WordList { get { return WordLists; } set { WordLists = value; } }

        Database dbE = new Database();

        public Language()
        {
            WordList = LanguageModel.Get("select * from language");
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
