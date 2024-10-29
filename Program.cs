namespace Program
{

    using System;
    using System.IO;
    using OfficeOpenXml;
    using System.Collections;
    using System.Collections.Generic;

    class Program
    {

        static void Main(string[] args)
        {
            String line;
            int i = 0;
            String[] ilIsimleri = new string[82];
            StreamReader sr = new StreamReader("/Users/furkan/Desktop/belge.txt");
    
            line = sr.ReadLine();
    
            while (line != null)
            {
                                                    // il isimleri için yeni bir string dizisi oluşturduk ve metin belgesinden
                ilIsimleri[i] = line;                   // verileri çektik.
                i++;
                line = sr.ReadLine();
            }

            
        

            int[,] uzaklikMatrisi = new int[82, 82];
            matrisOlustur(uzaklikMatrisi);


            ArrayList b = new ArrayList();
            //uzaklikListele(45,400,uzaklikMatrisi,ilIsimleri);
            //enYakin_enUzak_Listele(uzaklikMatrisi,ilIsimleri);
            //enFazlaKacIl(45,300,uzaklikMatrisi,b);
            
            
            randomUret(uzaklikMatrisi,ilIsimleri);
        }

        public static void uzaklikListele(int ilNo, int mesafe, int[,] uzaklikMatrisi,String[] ilIsimleri)
        {
            
            int geciciNo = 0;
            int ilSayisi = 0;
            ArrayList gidilebilecekIller = new ArrayList();
            ArrayList ozellikler = new ArrayList();

            int gidilebilecekIlSayisi = 0;

            for(int i =1; i < 82; i++)
            {
                if (uzaklikMatrisi[ilNo,i] <= mesafe && ilNo != i)
                {
                    String eklenecekIl = ilIsimleri[i];
                    int eklenecekMesafe = uzaklikMatrisi[ilNo,i];

                    ozellikler.Add(eklenecekIl);
                    ozellikler.Add(eklenecekMesafe);
                    gidilebilecekIller.Add(ozellikler);
                   
                    
                    
                    ilSayisi++;
                    

                }
            }
            Console.WriteLine(mesafe + " km mesafedeki gidilebilecek il sayısı:  " + ilSayisi );
            Console.WriteLine("Bu illerin isimleri ve " + ilIsimleri[ilNo] + " iline olan uzaklıkları: ");
             foreach(ArrayList a in gidilebilecekIller){

                Console.WriteLine("İl: " + a[geciciNo] + " \nUzaklık: " + a[geciciNo+1] + " km");  
                geciciNo = geciciNo +2;
               
            }
        }

        public static void enYakin_enUzak_Listele(int[,] uzaklik,String[] ilIsimleri)
        {   
            int[] enYakinIndeksler = new int[2];
            int[] enUzakIndeksler = new int[2];

            int enYakin = uzaklik[1,2];
            int enUzak = uzaklik[1,2];
            for(int row = 1; row<82; row++){
                for(int col = 1; col<82; col ++){
                    if(row != col){
                        if(uzaklik[row,col]<enYakin){
                            enYakin = uzaklik[row,col];
                            enYakinIndeksler[0] = row;
                            enYakinIndeksler[1] = col;
                        }
                        if(uzaklik[row,col]>enUzak){
                            enUzak = uzaklik[row,col];
                            enUzakIndeksler[0] = row;
                            enUzakIndeksler[1] = col;
                        }
                    }
                }
            }

            Console.WriteLine("Türkiye'de birbirine en yakın illerin isimleri: ");
            Console.WriteLine(ilIsimleri[enYakinIndeksler[0]]+ " ve " + ilIsimleri[enYakinIndeksler[1]]);
            Console.WriteLine(" Aralarındaki mesafe: " + enYakin + " km");

            Console.WriteLine("Türkiye'de birbirine en uzak illerin isimleri: ");
            Console.WriteLine(ilIsimleri[enUzakIndeksler[0]]+ " ve " + ilIsimleri[enUzakIndeksler[1]]);
            Console.WriteLine(" Aralarındaki mesafe: " + enUzak+ " km");

        }
         static void  enFazlaKacIl(int ilNo, int mesafe,int[,] uzaklik,ArrayList b)
        {   
            
            
                                           
            for(int i=1; i<82;i++) 
                                     
            {               
                List <int[]> a = new List<int[]>();                                   
                if(mesafe >= uzaklik[ilNo,i] && ilNo!=i)
                {     
                    int[] bilgiler = {i,uzaklik[ilNo,i]};
                    a.Add(bilgiler);
                    enFazlaKacIl(i,mesafe-uzaklik[ilNo,i],uzaklik,b);
                
                }
                b.Add(a);
            
           
            }
            
           
        } 


        static void randomUret(int[,] uzaklik, String[] ilIsimleri){
            
            int[,] matris = new int[5,5];
            Random rd1=new Random();
            int il1 = rd1.Next(1,81);
            int il2 = rd1.Next(1,81);                       
            int il3 = rd1.Next(1,81);
            int il4 = rd1.Next(1,81);
            int il5 = rd1.Next(1,81);
            while(il1 == il2 || il1 == il3 || il1 == il4 || il1 == il5 || il2 == il3 || il2 == il4 || il2 == il5 || il3 == il4 ||il3 == il5 || il4 == il5){  // aynı sayıyı üretmesine karşın kontrol
                il1 = rd1.Next(1,81);
                il2 = rd1.Next(1,81);                       
                il3 = rd1.Next(1,81);
                il4 = rd1.Next(1,81);
                il5 = rd1.Next(1,81);
            }
            
            int[] ilPlakalari = {il1,il2,il3,il4,il5};
            for(int i = 0; i < 5; i++){
                for(int j = 0; j<5; j++){
                    matris[i,j] = uzaklik[ilPlakalari[i],ilPlakalari[j]];
                }
            }
            Console.WriteLine(" ".PadLeft(18)+ilIsimleri[ilPlakalari[0]].PadRight(18) +ilIsimleri[ilPlakalari[1]].PadRight(18) +ilIsimleri[ilPlakalari[2]].PadRight(18)+ ilIsimleri[ilPlakalari[3]].PadRight(18)+ilIsimleri[ilPlakalari[4]].PadRight(18));
            for(int k=0;k<5;k++){
                Console.Write(ilIsimleri[ilPlakalari[k]].PadRight(18));
                for(int i = 0; i<5;i++){

                    Console.Write(Convert.ToString(matris[k,i]).PadRight(18));
                }
                Console.WriteLine();
            }
        }


        public static void matrisOlustur(int[,] uzaklikMatrisi)
        {

            FileInfo fileInfo = new FileInfo("/Users/furkan/Desktop/ilmesafe.xlsx");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                for (int i = 0; i < 82; i++)
                {
                    uzaklikMatrisi[i, 0] = 0;
                    uzaklikMatrisi[0, i] = 0;
                }


                for (int row = 1; row < 82; row++)
                {
                    for (int col = 1; col < 82; col++)
                    {

                        if (int.TryParse(worksheet.Cells[row+2 , col+2].Value?.ToString(), out int value))
                        {
                            uzaklikMatrisi[row, col] = value;
                        }
                        else
                        {

                            uzaklikMatrisi[row, col] = 0;
                        }
                    }
                }
            }
        }

    }
}




    



    