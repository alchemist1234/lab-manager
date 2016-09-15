using LabManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManager.View
{
    public partial class MainView
    {
        static List<Precursor> listPre;
        public static List<Precursor> ListPre
        {
            get { return listPre; }
        }
        void SetListPre()
        {
            listPre = new List<Precursor>
            {
                new Precursor("1-苯基-2-丙酮","phenylacetone","103-79-7",PrecursorType.第一类),
                new Precursor("3,4-亚甲基二氧苯基-2-丙酮","piperonyl methyl ketone","4676-39-5",PrecursorType.第一类),
                new Precursor("胡椒醛","piperonyl aldehyde","4676-39-5",PrecursorType.第一类),
                new Precursor("黄樟素","safrole","94-59-7",PrecursorType.第一类),
                new Precursor("黄樟油","sassafras oil","8006-80-2",PrecursorType.第一类),
                new Precursor("异黄樟素","isosafrole","120-58-1",PrecursorType.第一类),
                new Precursor("N-乙酰邻氨基苯酸","N-acetylanthranilic acid","89-52-1",PrecursorType.第一类),
                new Precursor("邻氨基苯甲酸","anthranilic acid","118-92-3",PrecursorType.第一类),
                new Precursor("麦角酸","9,10-dedehydro-6-methyl-ergoline-8-carboxylic acid","82-58-6",PrecursorType.第一类),
                new Precursor("麦角胺","ergotamine","113-15-5",PrecursorType.第一类),
                new Precursor("麦角新碱","ergonovine","113-15-5",PrecursorType.第一类),
                new Precursor("麻黄素","ephedrine","299-42-3",PrecursorType.第一类),
                new Precursor("伪麻黄素","pseudoephedrine","90-82-4",PrecursorType.第一类),
                new Precursor("消旋麻黄素","racephedrine","90-81-3",PrecursorType.第一类),
                new Precursor("去甲麻黄素","DL-norephedrine hydrochloride","154-41-6",PrecursorType.第一类),
                new Precursor("甲基麻黄素"," (-)-N-methylephedrine","552-79-4",PrecursorType.第一类),
                new Precursor("苯乙酸","phenylacetic acid","103-82-2",PrecursorType.第二类),
                new Precursor("醋酸酐","acetic anhydride","108-24-7",PrecursorType.第二类),
                new Precursor("三氯甲烷","chloroform","67-66-3",PrecursorType.第二类),
                new Precursor("乙醚","diethyl ether","60-29-7",PrecursorType.第二类),
                new Precursor("哌啶","1-oxa-4-azacyclohexane","110-89-4",PrecursorType.第二类),
                new Precursor("甲苯","toluene","108-88-3",PrecursorType.第三类),
                new Precursor("丙酮","acetone","67-64-1",PrecursorType.第三类),
                new Precursor("甲基乙基酮","2-butanone","78-93-3",PrecursorType.第三类),
                new Precursor("高锰酸钾","potassium permanganate","7722-64-7",PrecursorType.第三类),
                new Precursor("硫酸","sulfuric acid","7664-93-9",PrecursorType.第三类),
                new Precursor("盐酸","hydrochloric acid","7647-01-0",PrecursorType.第三类),
            };
        }
    }
}
