

///https://docs.logo.com.tr/public/wua/logo-objects/logo-objects-baslangic
/*
 * comexp.msc /32
 * 
 * https://www.youtube.com/watch?v=WRxuse5WUOs&feature=youtu.be
 * https://www.youtube.com/watch?v=gpxYkEf2uLo&feature=youtu.be 
 * 
 * 
 * http://www.logodestek.gen.tr/index.php?topic=10083.0;wap2
 * 
 */

using IZOKALE_WEBSERVICE.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace IZOKALE_WEBSERVICE
{
    /// <summary>
    /// Summary description for IZOKALEAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IZOKALEAPI : System.Web.Services.WebService
    {

        string IzoKaleFirmaNo = "";
        string IzoKaleDonemNo = "";
        public string IzoKaleConnectionString = "data source = 192.168.1.57; MultipleActiveResultSets=True; initial catalog = TIGERDB; User Id = sa; Password=Marka.2023";
        public string LbsLoadSecurityCode = "";


        public IZOKALEAPI()
        {

            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdMalzemeler = new SqlCommand();
                cmdMalzemeler.Connection = con;
                cmdMalzemeler.CommandText = "select * from IZOKALE_PARAMETRELER";
                SqlDataReader rdMalzemeler = cmdMalzemeler.ExecuteReader();
                while (rdMalzemeler.Read())
                {
                    if (rdMalzemeler["ParametreAdi"].ToString() == "FirmaNo")
                    {
                        IzoKaleFirmaNo = rdMalzemeler["ParametreDegeri"].ToString();
                    }
                    if (rdMalzemeler["ParametreAdi"].ToString() == "DönemNo")
                    {
                        IzoKaleDonemNo = rdMalzemeler["ParametreDegeri"].ToString();
                    }

                }
            }

        }


        //[WebMethod]
        //public string CariyiBayidenAyir(string LOGICALREF)
        //{
        //    using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
        //    {
        //        con.Open();
        //        SqlCommand cmdYeniMusteriler = new SqlCommand();
        //        cmdYeniMusteriler.Connection = con;
        //        cmdYeniMusteriler.CommandText = "delete from LG_CVARPASG where LOGICALREF=" + LOGICALREF;
        //        cmdYeniMusteriler.ExecuteNonQuery();
        //        con.Close();
        //        return "ok";

        //    }
        //}

        //[WebMethod]
        //public string BayiyeCariBagla(string MusteriLREF, string CariLREF)
        //{
        //    using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
        //    {
        //        con.Open();
        //        SqlCommand cmdYeniMusteriler = new SqlCommand();
        //        cmdYeniMusteriler.Connection = con;
        //        cmdYeniMusteriler.CommandText = "   DECLARE @ARPREF VARCHAR(MAX)" +
        //                                        "   DECLARE @CARIKODU VARCHAR(MAX)" +
        //                                        "   DECLARE @CARIADI VARCHAR(MAX)" +
        //                                        "   DECLARE @ADDR1 VARCHAR(MAX)" +
        //                                        "   DECLARE @ADDR2 VARCHAR(MAX)" +
        //                                        "   DECLARE @CITY VARCHAR(MAX)" +
        //                                        "   DECLARE @TOWN VARCHAR(MAX)" +
        //                                        "   DECLARE @EMAILADDR VARCHAR(MAX)" +
        //                                        "   DECLARE @TELNRS1 VARCHAR(MAX)" +
        //                                        "   DECLARE @TELNRS2 VARCHAR(MAX)" +
        //                                        "   select @TELNRS2 = TELNRS2,@TELNRS1 = TELNRS1,@EMAILADDR = EMAILADDR,@TOWN = TOWN,@CITY = CITY,@ADDR2 = ADDR2,@ADDR1 = ADDR1,@ARPREF = LOGICALREF, @CARIKODU = CODE, @CARIADI = DEFINITION_ from LG_" + IzoKaleFirmaNo + "_CLCARD where LOGICALREF = " + CariLREF + "" +
        //                                        "   insert into LG_CVARPASG(CSTVNDREF, ARPREF, CARIKODU, FIRMNO, CARIADI) values(" + MusteriLREF + ", @ARPREF, @CARIKODU," + IzoKaleFirmaNo + ", @CARIADI)" +
        //                                        "   update LG_CSTVND set TELNR2 = @TELNRS2,TELNR1 = @TELNRS1,WEBURL = @EMAILADDR,TOWN = @TOWN,CITY = @CITY,ADDR2 = @ADDR2,ADDR1 = @ADDR1 where LOGICALREF=" + MusteriLREF;
        //        cmdYeniMusteriler.ExecuteNonQuery();
        //        con.Close();
        //        return "ok";

        //    }
        //}


        //[WebMethod]
        //public string CariHesaplar(string temp)
        //{
        //    using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
        //    {
        //        con.Open();
        //        SqlCommand cmdCariler = new SqlCommand();
        //        cmdCariler.Connection = con;
        //        cmdCariler.CommandText = "select * from LG_" + IzoKaleFirmaNo + "_CLCARD where ACTIVE=0 and SUBSTRING(CODE, 1, 3)='120' and (DEFINITION_ like '%" + temp + "%' or CODE like '%" + temp + "%' or CITY like '%" + temp + "%')";
        //        SqlDataReader rdCariler = cmdCariler.ExecuteReader();
        //        DataTable dtCariler = new DataTable();
        //        dtCariler.Load(rdCariler);
        //        return JsonConvert.SerializeObject(dtCariler, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        //    }
        //}
        //[WebMethod]
        //public string YeniBayi(string BayiAdi)
        //{
        //    BayiAdi = BayiAdi.ToUpper();
        //    string durum = "";
        //    using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
        //    {

        //        con.Open();
        //        SqlCommand cmdMusteriler = new SqlCommand();
        //        cmdMusteriler.Connection = con;
        //        cmdMusteriler.CommandText = "select * from LG_CSTVND where TITLE=@title";
        //        cmdMusteriler.Parameters.AddWithValue("@title", BayiAdi);
        //        SqlDataReader rdMusteriler = cmdMusteriler.ExecuteReader();
        //        DataTable dtMusteriler = new DataTable();
        //        dtMusteriler.Load(rdMusteriler);
        //        if (dtMusteriler.Rows.Count == 0)
        //        {
        //            SqlCommand cmdYeniMusteriler = new SqlCommand();
        //            cmdYeniMusteriler.Connection = con;
        //            cmdYeniMusteriler.CommandText = "insert into LG_CSTVND (TITLE,ACTIVE,CARDTYPE) values (@title,0,1); " +
        //                "update LG_CSTVND set CODE='K'+CAST(LOGICALREF+100 as nvarchar(20)) where TITLE=@title";
        //            cmdYeniMusteriler.Parameters.AddWithValue("@title", BayiAdi);
        //            cmdYeniMusteriler.ExecuteNonQuery();
        //            durum = "ok";
        //        }
        //        else
        //        {
        //            durum = "Bu Bayi Adı Zaten Var";
        //        }
        //        con.Close();
        //    }
        //    return durum;
        //}

        [WebMethod]
        public List<Musteriler> Bayiler()
        {
            List<Musteriler> Bayiler = new List<Musteriler>();

            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdMusteriler = new SqlCommand();
                cmdMusteriler.Connection = con;
                string sorgu = "SELECT 'SUCCESS' AS Sonuc, (CASE WHEN CUSTCAT = 1 THEN 'GirisOk' ELSE 'TeknikProblem' END) Izin, "
                           + "   CODE,LOGICALREF, "
                           + " 	TITLE, "
                           + " 	TELNR1, "
                           + " 	TELNR2, "
                           + "     ADDR1,"
                           + "      ADDR2, "
                           + "     TOWN, "
                           + "     CITY, "
                           + "     COUNTRY, "
                           + " 	WEBURL "
                           + " FROM LG_CSTVND "
                           + " WHERE ACTIVE = 0 AND CARDTYPE = 1  "
                           + " ORDER BY CODE";
                cmdMusteriler.CommandText = sorgu;
                SqlDataReader rdMusteriler = cmdMusteriler.ExecuteReader();
                DataTable dtMusteriler = new DataTable();
                dtMusteriler.Load(rdMusteriler);

                for (int i = 0; i < dtMusteriler.Rows.Count; i++)
                {
                    Musteriler musteri = new Musteriler();
                    musteri.BayiKodu = dtMusteriler.Rows[i]["CODE"].ToString();
                    musteri.LOGICALREF = dtMusteriler.Rows[i]["LOGICALREF"].ToString();
                    musteri.BayiAdi = dtMusteriler.Rows[i]["TITLE"].ToString();
                    musteri.ADDR1 = dtMusteriler.Rows[i]["ADDR1"].ToString();
                    musteri.ADDR2 = dtMusteriler.Rows[i]["ADDR2"].ToString();
                    musteri.CITY = dtMusteriler.Rows[i]["CITY"].ToString();
                    musteri.TELNR1 = dtMusteriler.Rows[i]["TELNR1"].ToString();
                    musteri.TELNR2 = dtMusteriler.Rows[i]["TELNR2"].ToString();
                    musteri.WEBURL = dtMusteriler.Rows[i]["WEBURL"].ToString();
                    musteri.TOWN = dtMusteriler.Rows[i]["TOWN"].ToString();


                    Bayiler.Add(musteri);
                }
                con.Close();
            }
            return Bayiler;

        }


        [WebMethod]
        public string IlveIlceleriGetir()
        {
            List<IlBilgileri> Iller = new List<IlBilgileri>();

            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdIller = new SqlCommand();
                cmdIller.Connection = con;
                cmdIller.CommandText = "select * from L_CITY where COUNTRY in (select top 1 LOGICALREF from L_COUNTRY where CODE='TR')";
                SqlDataReader rdIller = cmdIller.ExecuteReader();

                SqlCommand cmdIlceler = new SqlCommand();
                cmdIlceler.Connection = con;
                cmdIlceler.CommandText = "select * from L_TOWN where CNTRNR in (select top 1 LOGICALREF from L_COUNTRY where CODE='TR')";
                SqlDataReader rdIlceler = cmdIlceler.ExecuteReader();
                var dtIller = new DataTable();
                var dtIlceler = new DataTable();


                dtIller.Load(rdIller);
                dtIlceler.Load(rdIlceler);

                for (int i = 0; i < dtIller.Rows.Count; i++)
                {
                    IlBilgileri il = new IlBilgileri();
                    il.LOGICALREF = dtIller.Rows[i]["LOGICALREF"].ToString();
                    il.IlAdi = dtIller.Rows[i]["NAME"].ToString();
                    il.IlKodu = dtIller.Rows[i]["CODE"].ToString();
                    il.Ilceler = new List<IlceBilgileri>();
                    for (int j = 0; j < dtIlceler.Rows.Count; j++)
                    {
                        if (dtIller.Rows[i]["LOGICALREF"].ToString() == dtIlceler.Rows[j]["CTYREF"].ToString())
                        {
                            IlceBilgileri ilce = new IlceBilgileri();
                            ilce.LOGICALREF = dtIlceler.Rows[j]["LOGICALREF"].ToString();
                            ilce.IlKodu = dtIlceler.Rows[j]["CTYREF"].ToString();
                            ilce.IlceAdi = dtIlceler.Rows[j]["NAME"].ToString();
                            il.Ilceler.Add(ilce);

                        }

                    }
                    var merkezVarMi = il.Ilceler.Where(x => x.IlKodu == il.LOGICALREF && x.IlceAdi.ToLower() == "merkez").FirstOrDefault();
                    if (merkezVarMi == null)
                    {
                        IlceBilgileri ilce = new IlceBilgileri();
                        ilce.LOGICALREF = "-2";
                        ilce.IlKodu = il.LOGICALREF;
                        ilce.IlceAdi = "MERKEZ";
                        il.Ilceler.Add(ilce);

                    }
                    Iller.Add(il);
                }

                con.Close();
            }
            return JsonConvert.SerializeObject(Iller.OrderBy(x => x.IlAdi), new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }

        public bool FiyatListesineBagliNakliyeListesiVarMi(string fiyatListesiKodu)
        {
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdMalzemeler = new SqlCommand();
                cmdMalzemeler.Connection = con;
                DataTable dt = new DataTable();
                cmdMalzemeler.CommandText = $@"
                    select * from LG_{IzoKaleFirmaNo}_PRCLIST price inner join 
                    LG_{IzoKaleFirmaNo}_PROJECT proje on price.PROJECTREF=proje.LOGICALREF
                    where price.PTYPE=4 and proje.CODE='{fiyatListesiKodu}'
                    ";

                SqlDataReader rdNakliyeler = cmdMalzemeler.ExecuteReader();
                dt.Load(rdNakliyeler);
                con.Close();

                return dt.Rows.Count > 0;
            }
        }

        public NakliyeBilgileri NakliyeFiyati(string IlKodu, string IlAdi, string IlceAdi, bool fabrikaTeslimMi, string nakliyeParam1, string nakliyeParam2, string fiyatListesi)
        {
            NakliyeBilgileri NakliyeBilgileri = new NakliyeBilgileri();
            if (fabrikaTeslimMi)
            {
                NakliyeBilgileri.Statu = true;
                NakliyeBilgileri.NakliyeFiyatSayisi = 1;
                NakliyeBilgileri.NakliyeHatasi = "";
                NakliyeBilgileri.LOGICALREF = -1;
                NakliyeBilgileri.NakliyeBirimFiyatiTL = 0;
                NakliyeBilgileri.NakliyeAdi = "Fabrika Teslim Nakliye Fiyatı";
                NakliyeBilgileri.NakliyeBirimSeti = nakliyeParam2;
                NakliyeBilgileri.NakliyeKodu = "-1";
                return NakliyeBilgileri;
            }
            if (nakliyeParam1.Trim() == "" || nakliyeParam2.Trim() == "")
            {
                NakliyeBilgileri.Statu = false;
                NakliyeBilgileri.NakliyeFiyatSayisi = 0;
                NakliyeBilgileri.NakliyeHatasi = "Nakliye Fiyatı Girilmemiş";
                return NakliyeBilgileri;
            }


            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {

                con.Open();
                SqlCommand cmdMalzemeler = new SqlCommand();
                cmdMalzemeler.Connection = con;
                DataTable dt = new DataTable();
                cmdMalzemeler.CommandText = $@" select 
                                                 itemSRV.LOGICALREF, 
                                                 itemSRV.CODE as NakliyeKodu,
                                                 itemSRV.DEFINITION_ as NakliyeAdi,
                                                 birim.NAME as NakliyeBirimSeti, 
                                                 ISNULL(ISNULL(price.PRICE,0)*ISNULL((select TOP(1) CONVFACT2 from LG_{IzoKaleFirmaNo}_UNITSETL where CODE='{nakliyeParam2}' and UNITSETREF=itemSRV.UNITSETREF),0),0) as NakliyeBirimFiyatiTL,
                                                 ISNULL(proje.CODE,'') as FiyatListesi
                                                 from LG_{IzoKaleFirmaNo}_SRVCARD itemSRV left join 
                                                 LG_{IzoKaleFirmaNo}_PRCLIST price on itemSRV.LOGICALREF = price.CARDREF and price.ACTIVE = 0 and price.PTYPE=4 left join 
                                                 LG_{IzoKaleFirmaNo}_PROJECT proje on proje.LOGICALREF=price.PROJECTREF left join
                                                 LG_{IzoKaleFirmaNo}_UNITSETL birim on price.UOMREF = birim.LOGICALREF where ISNULL(proje.CODE,'')='{fiyatListesi}'";


                if (nakliyeParam1 == "NB")
                {
                    IlceAdi = IlceAdi.ToUpper();
                    if (IlceAdi.ToUpper() == "MERKEZ")
                    {
                        IlceAdi = IlAdi.ToUpper();
                    }
                    cmdMalzemeler.CommandText += " and SUBSTRING(itemSRV.CODE,0,5)= '" + nakliyeParam1 + IlKodu + "'  and itemSRV.DEFINITION_ like '%" + IlceAdi.ToUpper() + "%'";

                }
                else if (nakliyeParam1 == "NE")
                {
                    cmdMalzemeler.CommandText += " and SUBSTRING(itemSRV.CODE,0,3)='" + nakliyeParam1 + "' and itemSRV.DEFINITION_ like '%" + IlAdi.ToUpper() + "%'";

                }
                else
                {
                    NakliyeBilgileri.Statu = false;
                    NakliyeBilgileri.NakliyeFiyatSayisi = 0;
                    NakliyeBilgileri.NakliyeHatasi = "Nakliye Fiyatı Bulunamadı.";
                    return NakliyeBilgileri;
                }
                SqlDataReader rdNakliyeler = cmdMalzemeler.ExecuteReader();
                dt.Load(rdNakliyeler);




                if (dt.Rows.Count > 1)
                {
                    NakliyeBilgileri.Statu = false;
                    NakliyeBilgileri.NakliyeFiyatSayisi = dt.Rows.Count;
                    NakliyeBilgileri.NakliyeHatasi = dt.Rows.Count + " adet nakliye fiyatı girilmiş. ";
                }
                else if (dt.Rows.Count == 0)
                {
                    NakliyeBilgileri.Statu = false;
                    NakliyeBilgileri.NakliyeFiyatSayisi = dt.Rows.Count;
                    NakliyeBilgileri.NakliyeHatasi = "Nakliye Fiyatı Girilmemiş";
                }
                else if (dt.Rows.Count == 1)
                {
                    if (Convert.ToDouble(dt.Rows[0]["NakliyeBirimFiyatiTL"].ToString()) == 0)
                    {
                        NakliyeBilgileri.Statu = false;
                        NakliyeBilgileri.NakliyeFiyatSayisi = 0;
                        NakliyeBilgileri.NakliyeHatasi = "Nakliye Fiyatı Bulunamadı.";
                        return NakliyeBilgileri;
                    }
                    NakliyeBilgileri.Statu = true;
                    NakliyeBilgileri.NakliyeFiyatSayisi = dt.Rows.Count;
                    NakliyeBilgileri.NakliyeHatasi = "";
                    NakliyeBilgileri.LOGICALREF = Convert.ToInt32(dt.Rows[0]["LOGICALREF"].ToString());
                    NakliyeBilgileri.NakliyeBirimFiyatiTL = Convert.ToDouble(dt.Rows[0]["NakliyeBirimFiyatiTL"].ToString());
                    NakliyeBilgileri.NakliyeAdi = dt.Rows[0]["NakliyeAdi"].ToString();
                    NakliyeBilgileri.NakliyeBirimSeti = dt.Rows[0]["NakliyeBirimSeti"].ToString();
                    NakliyeBilgileri.NakliyeKodu = dt.Rows[0]["NakliyeKodu"].ToString();
                }

            }
            return NakliyeBilgileri;
        }

        public double BayiIskontosu(string BayiKodu, string SPECODE1)
        {

            try
            {

                using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
                {
                    con.Open();
                    SqlCommand cmdMalzemeler = new SqlCommand();
                    cmdMalzemeler.Connection = con;
                    cmdMalzemeler.CommandText =
                                      "select ISNULL(DISCRATE,0) from LG_" + IzoKaleFirmaNo + "_CLCARD where CODE='" + BayiKodu + "'";
                    double iskonto = Convert.ToDouble(cmdMalzemeler.ExecuteScalar().ToString().Replace(".", ","));
                    con.Close();
                    cmdMalzemeler.Dispose();
                    return iskonto;
                }
            }
            catch (Exception hata)
            {
                return 0;
            }


        }
        [WebMethod]
        public List<SistemKalemleriBilgileri> SistemKalemleriBilgileriAl(string anaGrup)
        {
            var List = new List<SistemKalemleriBilgileri>();
            List.Add(new SistemKalemleriBilgileri
            {
                Adi = "ISI YALITIM LEVHASI YAPIŞTIRMA HARCI",
                Kodu = "2500211",
                BirBirimeKullanilacakMiktar = 4,
                paketMiktari = 25
            });
            List.Add(new SistemKalemleriBilgileri
            {
                Adi = "ISI YALITIM LEVHASI SIVA HARCI ELYAF KATKI",
                Kodu = "2500212",
                BirBirimeKullanilacakMiktar = 5,
                paketMiktari = 25
            });
            List.Add(new SistemKalemleriBilgileri
            {
                Adi = "DEKORATİF SIVA -2000-MİN DOKULU BEYAZ",
                Kodu = "2500401",
                BirBirimeKullanilacakMiktar = 2.5,
                paketMiktari = 25
            });

            if (anaGrup == "KB_TASYUNU")
            {
                List.Add(new SistemKalemleriBilgileri
                {
                    Adi = "MANTOLAMA DÜBELİ 12 CM",
                    Kodu = "1531012",
                    BirBirimeKullanilacakMiktar = 2,
                    paketMiktari = 500
                });
                List.Add(new SistemKalemleriBilgileri
                {
                    Adi = "Çelik Dübel 11,5 Cm",
                    Kodu = "1531002",
                    BirBirimeKullanilacakMiktar = 4,
                    paketMiktari = 500
                });
            }
            if (anaGrup == "KB_EPS" || anaGrup == "KB_XPS")
            {
                List.Add(new SistemKalemleriBilgileri
                {
                    Adi = "MANTOLAMA DÜBELİ 12 CM",
                    Kodu = "1531012",
                    BirBirimeKullanilacakMiktar = 6,
                    paketMiktari = 500
                });
            }
            List.Add(new SistemKalemleriBilgileri
            {
                Adi = "SIVA FİLESİ TURUNCU",
                Kodu = "1530605",
                BirBirimeKullanilacakMiktar = 1.1,
                paketMiktari = 50
            });
            List.Add(new SistemKalemleriBilgileri
            {
                Adi = "FİLELİ KÖŞE PROFİLİ",
                Kodu = "1530607",
                BirBirimeKullanilacakMiktar = 0.25,
                paketMiktari = 125
            });
            return List;
        }

        public string FasonBayisiMarkalari(string BayiKodu)
        {
            string markalar = "";

            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdMalzemeler = new SqlCommand();
                cmdMalzemeler.Connection = con;
                cmdMalzemeler.CommandText = $@"
                 select ISNULL(cast(cast(LDATA As varbinary(MAX)) as varchar(MAX)),'') as TanimliMarkalar from LG_CSTVND musteri left join LG_SLSDOC notlar on musteri.LOGICALREF=notlar.INFOREF and INFOTYP=32
                 where musteri.CODE='{BayiKodu}'
                    ";
                SqlDataReader rdMalzemeler = cmdMalzemeler.ExecuteReader();
                while (rdMalzemeler.Read())
                {
                    var markalarDizisi = rdMalzemeler["TanimliMarkalar"].ToString().Trim().Split(',');
                    for (int i = 0; i < markalarDizisi.Length; i++)
                    {
                        if (markalarDizisi[i].Trim()=="")
                        {
                            continue;
                        }
                        markalar += "'" + markalarDizisi[i].Trim() + "',";
                    }
                    break;
                }
                con.Close();


            }
            return markalar != "" ? markalar.Substring(0, markalar.Length - 1) : ""; 
        }

        

        [WebMethod]
        public string MalzemeListesi(string BayiKodu, string FiyatListesiKodu, string baglantiLREF, string SPECODE1, string SPECODE2, string Il, string Ilce, bool fabrikaTeslimMi, double GuncelUSD, double GuncelEUR,string PAYPLANREF)
        {
            string IlText = "";
            string IlceText = "";
            var IlveIlceleri = JsonConvert.DeserializeObject<List<IlBilgileri>>(IlveIlceleriGetir());
            foreach (var item in IlveIlceleri.Where(x => x.LOGICALREF.ToString() == Il))
            {
                IlText = item.IlAdi;
                Il = item.IlKodu;
                foreach (var item2 in item.Ilceler.Where(x => x.LOGICALREF.ToString() == Ilce))
                {
                    Ilce = item2.IlceAdi;
                    IlceText = item2.IlceAdi;
                }
            }
         

            string fasonBayisiMarkalari = FasonBayisiMarkalari(BayiKodu);
            double indirimOrani = 0;
            double sozlesmeEUR = 0;
            double sozlesmeUSD = 0;
            bool fiyatListesineBagliNakliyeListesiVarMi = FiyatListesineBagliNakliyeListesiVarMi(FiyatListesiKodu);

            if (baglantiLREF != "-1")
            {
                var temp = SecilebilirFiyatListeleri(BayiKodu).Where(x => x.baglantiLREF == baglantiLREF).FirstOrDefault();
                indirimOrani = temp.iskontoOrani;
                sozlesmeEUR = temp.sozlesmeEUR;
                sozlesmeUSD = temp.sozlesmeUSD;
            }
            else
            {
                indirimOrani = BayiIskontosu(BayiKodu, SPECODE1);
            }
            if (SPECODE1 != "KB_BİMS" && SPECODE1 != "KB_YKİM")
            {
                indirimOrani = 0; 
            }
           


            List<Malzeme> Malzemeler = new List<Malzeme>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdMalzemeler = new SqlCommand();
                cmdMalzemeler.Connection = con;
                cmdMalzemeler.CommandText =
                                    " DECLARE @kategoriNo int =-1 " +
                                    "DECLARE @ilIzniVarMi bit=0 " +
                                    "select @kategoriNo=CUSTCAT from LG_CSTVND where CODE='" + BayiKodu + "' " +
                                    "select @ilIzniVarMi=1 from LG_CSTVND musteri inner join " +
                                    "LG_CVINDASG sektorIliski on musteri.LOGICALREF=sektorIliski.CSTVNDREF inner join " +
                                    "LG_INDUSTRY sektor on sektorIliski.INDREF=sektor.LOGICALREF " +
                                    "where musteri.CODE='" + BayiKodu + "' AND musteri.CUSTCAT=38 and SUBSTRING(sektor.CODE, CHARINDEX('#', sektor.CODE) + 1, LEN(sektor.CODE) - CHARINDEX('#', sektor.CODE))='" + FiyatListesiKodu + "' and sektor.DESCRIPTION='" + IlText + "' and sektorIliski.PRIMARYFLG=1 " +
                                    "IF (@kategoriNo=38 AND @ilIzniVarMi=1) or @kategoriNo!=38 " +
                                    "BEGIN " +
                                             " select @kategoriNo as kategoriNo,*," +
                                            " (case when BaseBirim = 0 then 'TL' when BaseBirim = 160 then 'TL' when BaseBirim = 1 then 'USD' when BaseBirim = 20 then 'EUR' else '' end) as BaseTopParaBirimi" +
                                            " from(" +
                                            "    select UNITB.CODE AS Birim, ITEM.LOGICALREF AS ITEMLREF,ITEM.KEYWORD1,ITEM.KEYWORD2, ITEM.LOGOID,ITEM.VAT as KDV, ITEM.CODE AS MalzemeKodu, ITEM.NAME as MalzemeAdi, ITEM.NAME4 AS MalzemeAciklama,ITEM.SPECODE,ITEM.SPECODE2, " +
                                            "    (SELECT COUNT(*)       FROM LG_" + IzoKaleFirmaNo + "_PRCLIST WITH(NOLOCK) WHERE ACTIVE=0 AND PTYPE = 2 AND PAYPLANREF= (CASE WHEN @kategoriNo=38 THEN '" + PAYPLANREF + "' ELSE '0' END) AND CARDREF = ITEM.LOGICALREF AND INCVAT = 0 AND DEFINITION_ = '" + FiyatListesiKodu + "') AS BaseFiyatSayisi," +
                                            "	(SELECT TOP 1 PRICE    FROM LG_" + IzoKaleFirmaNo + "_PRCLIST WITH(NOLOCK) WHERE ACTIVE=0 AND PTYPE = 2 AND PAYPLANREF= (CASE WHEN @kategoriNo=38 THEN '" + PAYPLANREF + "' ELSE '0' END) AND CARDREF = ITEM.LOGICALREF AND INCVAT = 0 AND DEFINITION_ = '" + FiyatListesiKodu + "') AS BaseTopFiyat," +
                                            "	(SELECT TOP 1 CURRENCY FROM LG_" + IzoKaleFirmaNo + "_PRCLIST WITH(NOLOCK) WHERE ACTIVE=0 AND PTYPE = 2 AND PAYPLANREF= (CASE WHEN @kategoriNo=38 THEN '" + PAYPLANREF + "' ELSE '0' END) AND CARDREF = ITEM.LOGICALREF AND INCVAT = 0 AND DEFINITION_ = '" + FiyatListesiKodu + "') AS BaseBirim, " +
                                            "	(select STRING_AGG(payplan.DEFINITION_+'=<b>'+ CONVERT(nvarchar,FORMAT(price.PRICE, 'N2')) +' TL</b>', '   ')  from LG_" + IzoKaleFirmaNo + "_PRCLIST price LEFT JOIN LG_" + IzoKaleFirmaNo + "_PAYPLANS payplan on price.PAYPLANREF=payplan.LOGICALREF WHERE price.ACTIVE=0 AND PTYPE = 2 AND CARDREF = ITEM.LOGICALREF AND INCVAT = 0 AND price.DEFINITION_ = '" + FiyatListesiKodu + "') AS DigerFiyatlar " +
                                           "    from LG_" + IzoKaleFirmaNo + "_ITEMS ITEM" +
                                            " LEFT JOIN LG_" + IzoKaleFirmaNo + "_UNITSETF UNITA  WITH (NOLOCK) ON UNITA.LOGICALREF = ITEM.UNITSETREF " +
                                            " LEFT JOIN LG_" + IzoKaleFirmaNo + "_UNITSETL UNITB  WITH (NOLOCK) ON UNITA.LOGICALREF = UNITB.UNITSETREF AND UNITB.MAINUNIT=1 " +
                                            " WHERE(ITEM.ACTIVE = 0)   AND(ITEM.SPECODE = '" + SPECODE1 + "') AND " +
                                            (fasonBayisiMarkalari != "" ? "(ITEM.SPECODE5='FLOW' OR (ITEM.SPECODE5='FASON' AND ITEM.MARKREF in (select LOGICALREF from LG_" + IzoKaleFirmaNo + "_MARK where CODE in (" + fasonBayisiMarkalari + "))))" : " ITEM.SPECODE5='FLOW'") +
                                            ")  aaa " +
                                    "END " +
                                    "ELSE " +
                                    "select * from (select  @kategoriNo as kategoriNo,'' AS Birim, '' AS ITEMLREF,'' KEYWORD1,'' KEYWORD2, '' LOGOID,''  as KDV, '' AS MalzemeKodu, '' as MalzemeAdi,'' AS MalzemeAciklama,'' SPECODE,'' SPECODE2,'' BaseFiyatSayisi,'' BaseTopFiyat,'' BaseBirim,'' BaseTopParaBirimi where 1=0 ) aaaa";

                if (SPECODE2 != "")
                {
                    cmdMalzemeler.CommandText = cmdMalzemeler.CommandText + " where (SPECODE2 = '" + SPECODE2 + "')";
                }

                SqlDataReader rdMalzemeler = cmdMalzemeler.ExecuteReader();
                while (rdMalzemeler.Read())
                {
                   
                    Malzeme malzeme = new Malzeme();
                    malzeme.Success = true;
                    malzeme.HataMesaji = "";
                    NakliyeBilgileri nakliyeBilgileri;
                    if(rdMalzemeler["kategoriNo"].ToString()=="38")
                    {
                        nakliyeBilgileri = new NakliyeBilgileri()
                        {
                            Statu=true,
                            NakliyeBirimFiyatiTL=0,

                        };
                    }
                    else
                    {
                        nakliyeBilgileri = NakliyeFiyati(Il, IlText, IlceText, fabrikaTeslimMi, rdMalzemeler["KEYWORD1"].ToString(), rdMalzemeler["KEYWORD2"].ToString(), fiyatListesineBagliNakliyeListesiVarMi ? FiyatListesiKodu : "");

                    }

                    if (nakliyeBilgileri.Statu == false)
                    {
                        malzeme.HataMesaji = malzeme.HataMesaji + "\n " + rdMalzemeler["MalzemeKodu"].ToString() + " için " + nakliyeBilgileri.NakliyeHatasi;

                    }


                    if (Convert.ToInt32(rdMalzemeler["BaseFiyatSayisi"].ToString()) == 0)
                    {
                        malzeme.HataMesaji = malzeme.HataMesaji + "\n " + rdMalzemeler["MalzemeKodu"].ToString() + " için " + FiyatListesiKodu + " listesinde fiyat girilmemiş. ";
                    }
                    if (Convert.ToInt32(rdMalzemeler["BaseFiyatSayisi"].ToString()) > 1)
                    {
                        malzeme.HataMesaji = malzeme.HataMesaji + "\n " + rdMalzemeler["MalzemeKodu"].ToString() + " için " + FiyatListesiKodu + " listesinde mükerrer fiyat bulunuyor. ";
                    }
                    string BaseDoviz = rdMalzemeler["BaseTopParaBirimi"].ToString();
                    double BaseTopFiyat = 0;
                    if (Convert.ToInt32(rdMalzemeler["BaseFiyatSayisi"].ToString()) == 1)
                    {
                        BaseTopFiyat = Convert.ToDouble(rdMalzemeler["BaseTopFiyat"].ToString());
                    }
                    if (malzeme.HataMesaji != "")
                    {

                        malzeme.BaseFiyat = 0;
                        malzeme.BaseDoviz = "";
                        nakliyeBilgileri.NakliyeBirimFiyatiTL = 0;
                    }
                    else
                    {
                        malzeme.BaseFiyat = BaseTopFiyat;
                        malzeme.BaseDoviz = BaseDoviz;
                    }
                    malzeme.HesaplamaDetayliAciklama = FiyatListesiKodu;
                    malzeme.HesaplamaDetayliAciklama = malzeme.HesaplamaDetayliAciklama + "  B.Fiyat: " + BaseTopFiyat + BaseDoviz;

                    if (sozlesmeEUR > 1 || sozlesmeUSD > 1)
                    {
                        malzeme.HesaplamaDetayliAciklama = malzeme.HesaplamaDetayliAciklama + "  Sabit Kurlar: " + " USD(" + sozlesmeUSD + ") " + " EUR(" + sozlesmeEUR + ")";

                        if (BaseDoviz == "USD")
                        {
                            malzeme.HesaplanmisBirimFiyatiTL = malzeme.BaseFiyat * Convert.ToDouble(sozlesmeUSD);
                        }
                        if (BaseDoviz == "EUR")
                        {
                            malzeme.HesaplanmisBirimFiyatiTL = malzeme.BaseFiyat * Convert.ToDouble(sozlesmeEUR);
                        }

                    }
                    else
                    {
                        malzeme.HesaplamaDetayliAciklama = malzeme.HesaplamaDetayliAciklama + "  Güncel Kurlar: " + " USD(" + GuncelUSD + ") " + " EUR(" + GuncelEUR + ")";

                        if (BaseDoviz == "USD")
                        {
                            malzeme.HesaplanmisBirimFiyatiTL = malzeme.BaseFiyat * Convert.ToDouble(GuncelUSD);
                        }
                        if (BaseDoviz == "EUR")
                        {
                            malzeme.HesaplanmisBirimFiyatiTL = malzeme.BaseFiyat * Convert.ToDouble(GuncelEUR);
                        }

                    }
                    if (BaseDoviz == "TL")
                    {
                        malzeme.HesaplanmisBirimFiyatiTL = malzeme.BaseFiyat * Convert.ToDouble(1);
                    }

                    if (indirimOrani != 0)
                    {
                        malzeme.HesaplanmisBirimFiyatiTL = malzeme.HesaplanmisBirimFiyatiTL - (malzeme.HesaplanmisBirimFiyatiTL * (indirimOrani / 100));
                        malzeme.HesaplamaDetayliAciklama += " %" + indirimOrani + " " + (baglantiLREF == "-1" ? "Bayi" : "Bağlantı") + " İskontosu";
                    }
                    malzeme.NakliyeMasrafiTL = nakliyeBilgileri.NakliyeBirimFiyatiTL;
                    if (malzeme.NakliyeMasrafiTL > 0)
                    {
                        malzeme.HesaplanmisBirimFiyatiTL += malzeme.NakliyeMasrafiTL;
                        malzeme.HesaplamaDetayliAciklama = malzeme.HesaplamaDetayliAciklama + "  Nakliye: " + malzeme.NakliyeMasrafiTL + " TL " + nakliyeBilgileri.NakliyeAdi;

                        malzeme.NakliyeKartiLref = nakliyeBilgileri.LOGICALREF;
                        malzeme.NakliyeAdi = nakliyeBilgileri.NakliyeAdi;
                        malzeme.NakliyeBirimSeti = nakliyeBilgileri.NakliyeBirimSeti;
                        malzeme.NakliyeKodu = nakliyeBilgileri.NakliyeKodu;
                    }




                    malzeme.SPECODE1 = rdMalzemeler["SPECODE"].ToString();
                    malzeme.SPECODE2 = rdMalzemeler["SPECODE2"].ToString();
                    malzeme.DigerFiyatlar = rdMalzemeler["DigerFiyatlar"].ToString();
                    malzeme.Kdv = Convert.ToDouble(rdMalzemeler["KDV"].ToString());
                    malzeme.sozlesmeEUR = 1;
                    malzeme.sozlesmeUSD = 1;
                    malzeme.GuncelEUR = GuncelEUR;
                    malzeme.GuncelUSD = GuncelUSD;

                    malzeme.MalzemeKodu = rdMalzemeler["MalzemeKodu"].ToString();
                    malzeme.MalzemeAdi = rdMalzemeler["MalzemeAdi"].ToString();
                    malzeme.MalzemeAciklama = rdMalzemeler["MalzemeAciklama"].ToString();
                    malzeme.Birim = rdMalzemeler["Birim"].ToString();
                    Malzemeler.Add(malzeme);
                }
                con.Close();
            }

            return JsonConvert.SerializeObject(Malzemeler, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }
        [WebMethod]
        public string YonetimRaporlari(string tabloAdi)
        {
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdMalzemeler = new SqlCommand();
                DataTable dt = new DataTable();
                cmdMalzemeler.Connection = con;
                cmdMalzemeler.CommandText = "select * from " + tabloAdi;
                var dr = cmdMalzemeler.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                con.Close();
                cmdMalzemeler.Dispose();
                var aaaaaa = JsonConvert.SerializeObject(dt, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" }); ;
                return JsonConvert.SerializeObject(dt, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });
            }
        }

        [WebMethod]
        public List<FiyatListesiBakiye> SecilebilirFiyatListeleri(string BayiKodu)
        {

            //List<FiyatListesiBakiye> Baglantilar = new List<FiyatListesiBakiye>();
            //using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            //{
            //    con.Open();
            //    SqlCommand cmdBaglantiBakiyeOzeti = new SqlCommand();
            //    cmdBaglantiBakiyeOzeti.Connection = con;
            //    cmdBaglantiBakiyeOzeti.CommandText = "select CODE as FiyatListesi,NAME as Aciklama,LOGICALREF as BaglantiLREF  from LG_" + IzoKaleFirmaNo + "_PROJECT where ACTIVE=0 and SPECODE='001'";






            //    SqlDataReader rdBaglantiBakiyeOzeti = cmdBaglantiBakiyeOzeti.ExecuteReader();
            //    while (rdBaglantiBakiyeOzeti.Read())
            //    {
            //        FiyatListesiBakiye baglanti = new FiyatListesiBakiye();
            //        baglanti.siparisTutari = String.Format("{0:N}", Convert.ToDouble("0"));
            //        baglanti.baglantiTutari = String.Format("{0:N}", Convert.ToDouble("0"));
            //        baglanti.bakiye = String.Format("{0:N}", Convert.ToDouble("0"));
            //        baglanti.fiyatListesiKodu = rdBaglantiBakiyeOzeti["FiyatListesi"].ToString();
            //        baglanti.Aciklama = rdBaglantiBakiyeOzeti["Aciklama"].ToString();
            //        baglanti.baglantiLREF = rdBaglantiBakiyeOzeti["BaglantiLREF"].ToString();

            //        Baglantilar.Add(baglanti);


            //    }

            //    con.Close();
            //}

            //return JsonConvert.SerializeObject(Baglantilar, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

            List<FiyatListesiBakiye> Baglantilar = new List<FiyatListesiBakiye>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdBaglantiBakiyeOzeti = new SqlCommand();
                cmdBaglantiBakiyeOzeti.Connection = con;
                cmdBaglantiBakiyeOzeti.CommandText =

                      "DECLARE @kategoriNumarasi int;" +
                      "select @kategoriNumarasi=CUSTCAT from LG_CSTVND where CODE='"+BayiKodu+"' " +
                      "" +
                      "" +
                      "SELECT MusteriKodu, MusteriAdi, BaglantiLREF, FiyatListesi,  "
               + "\n	 (CASE WHEN((SabitKurUSD > 1) and(SabitKurEUR > 1)) THEN Aciklama +' [Sabit Kur: USD:' + CAST(SabitKurUSD AS VARCHAR) + ' EUR:' + CAST(SabitKurEUR AS VARCHAR) + ']' "
               + "\n        WHEN BaglantiTutari > 1 then Aciklama +' [Güncel Dövizli Bağlantı]' "
               + "\n            ELSE '' "
               + "\n    END)+' '+SozlesmeFisNo AS Aciklama, BaglantiTutari, SiparisTutari, Bakiye,SozlesmeIskontosu,SabitKurUSD,SabitKurEUR "

               + "\n     FROM "
               + "\n     ( "
               + "\n          SELECT "

               + "\n          MusteriKodu, MusteriAdi, BaglantiLREF, FiyatListesi, "
               + "\n          MAX(Aciklama) as Aciklama, "
               + "\n          MAX(SozlesmeFisNo) as SozlesmeFisNo, "

               //  + "\n          ISNULL(CONVERT(VARCHAR,(ISNULL(MAX(SabitKurTarihi), 0)), 104), '') AS SabitKurTarihi, "
               + "\n          MAX(SabitKurUSD) as SabitKurUSD, "
               + "\n          MAX(SabitKurEUR) AS SabitKurEUR, "
               + "\n          SUM(BaglantiTutari) AS BaglantiTutari, "
               + "\n          SUM(SiparisTutari) AS SiparisTutari, "
               + "\n          (CASE WHEN SUM(BaglantiTutari) = 0 THEN 0  ELSE SUM(BaglantiTutari) - SUM(SiparisTutari)  END) as Bakiye, SozlesmeIskontosu "


               + "\n          FROM "
               + "\n          ( "


               + "\n                  SELECT "
               + "\n                  'Sipariş ' AS Tip, "
               + "\n                  '' AS SozlesmeFisNo, "
               + "\n                  ISNULL(MUSTERI.CODE, '-') AS MusteriKodu, "
               + "\n                  ISNULL(MUSTERI.TITLE, '!! MÜŞTERİYE BAĞLANMAMIŞ !!') AS MusteriAdi, "
               + "\n                  (select NAME from LG_" + IzoKaleFirmaNo + "_PROJECT where LOGICALREF=ISNULL(SOZLESME.PROJECTREF, -1)) AS FiyatListesi, "
               + "\n                  0 AS BaglantiTutari, "
               + "\n                  (SELECT SUM((CASE WHEN CLOSED = 1 THEN AMOUNT ELSE AMOUNT END) * (LINENET / AMOUNT) * (100 + VAT) / 100) FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFLINE WHERE (LINETYPE = 0 OR LINETYPE = 4) AND CANCELLED = 0 AND ORDFICHEREF = SIPARIS.LOGICALREF) AS SiparisTutari, "
               + "\n                  ISNULL(SOZLESME.LOGICALREF, 0) AS BaglantiLREF, "
               + "\n                   ISNULL((SELECT TEXTFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),'') AS Aciklama, "
               //    + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurTarihi, "
               + "\n                   ISNULL((SELECT NUMFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurUSD, "
               + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurEUR, "
               + "\n                   (select top(1) SPECODE from LG_" + IzoKaleFirmaNo + "_PURCHOFFERLN where ORDFICHEREF=SOZLESME.LOGICALREF order by SPECODE desc) as SozlesmeIskontosu  "

               + "\n                  FROM "
               + "\n                  LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFICHE SIPARIS "
               + "\n                   LEFT JOIN LG_" + IzoKaleFirmaNo + "_PURCHOFFER SOZLESME ON SIPARIS.OFFERREF = SOZLESME.LOGICALREF AND SOZLESME.TRCODE = 1 AND SOZLESME.TYP = 2 AND SOZLESME.CANCELLED = 0 "
               + "\n                    LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI ON SIPARIS.CLIENTREF = CARI.LOGICALREF "
               + "\n                     LEFT JOIN LG_CVARPASG ILISKI ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo + " "
               + "\n                      LEFT JOIN LG_CSTVND MUSTERI ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 "
               + "\n                  WHERE SIPARIS.CANCELLED = 0 AND SIPARIS.STATUS != 2 AND SIPARIS.TRCODE = 1 AND MUSTERI.CODE = '" + BayiKodu + "' "


               + "\n                  UNION ALL "


               + "\n                  SELECT "
               + "\n                  'Sözleşme' AS Tip, "
               + "\n                  SOZLESME.FICHENO AS SozlesmeFisNo, "
               + "\n                  ISNULL(MUSTERI.CODE, '-') AS MusteriKodu, "
               + "\n                  ISNULL(MUSTERI.TITLE, '!! MÜŞTERİYE BAĞLANMAMIŞ !!') AS MusteriAdi,  "
               + "\n                  (select NAME from LG_" + IzoKaleFirmaNo + "_PROJECT where LOGICALREF=ISNULL(SOZLESME.PROJECTREF, -1)) AS FiyatListesi, "
               + "\n                  ISNULL(SOZLESME.NETTOTAL, 0) AS BaglantiTutari, "
               + "\n                  0 AS SiparisTutari, "
               + "\n                  ISNULL(SOZLESME.LOGICALREF, 0) AS BaglantiLREF, "
               + "\n                   ISNULL((SELECT TEXTFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),'') AS Aciklama, "
               //   + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurTarihi,"
               + "\n                   ISNULL((SELECT NUMFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurUSD, "
               + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurEUR, "
               + "\n                   (select top(1) SPECODE from LG_" + IzoKaleFirmaNo + "_PURCHOFFERLN where ORDFICHEREF=SOZLESME.LOGICALREF order by SPECODE desc) as SozlesmeIskontosu "

               + "\n                  FROM "
               + "\n                    LG_" + IzoKaleFirmaNo + "_PURCHOFFER SOZLESME  "
               + "\n                     LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI ON SOZLESME.CLIENTREF = CARI.LOGICALREF "
               + "\n                      LEFT JOIN LG_CVARPASG ILISKI ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo + " "
               + "\n                       LEFT JOIN LG_CSTVND MUSTERI ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 "
               + "\n                  WHERE SOZLESME.TRCODE = 1 AND SOZLESME.TYP = 2 AND SOZLESME.CANCELLED = 0 AND MUSTERI.CODE = '" + BayiKodu + "' "

               + "\n          ) AS AA  GROUP BY MusteriKodu,MusteriAdi, FiyatListesi , BaglantiLREF,SozlesmeIskontosu "

               + "\n     ) AS SASAS "
               + "\n     WHERE(BaglantiTutari > 1) AND (Bakiye > 100) "



                + "\n UNION ALL "

                + "\n SELECT '' AS MusteriKodu, '' AS MusteriAdi, -1 AS BaglantiLREF, CODE AS FiyatListesi, '' as Aciklama, 0 as BaglantiTutari, 0 as SiparisTutari, 0 as Bakiye,'' as SozlesmeIskontosu,0 as SabitKurEUR,0 as SabitKurUSD from LG_" + IzoKaleFirmaNo + "_PROJECT where ACTIVE=0 and SPECODE='001'" +
                "and (CODE IN(" +
                " select SUBSTRING(sektor.CODE, CHARINDEX('#', sektor.CODE) + 1, LEN(sektor.CODE) - CHARINDEX('#', sektor.CODE)) from LG_CSTVND musteri inner join" +
                " LG_CVINDASG sektorIliski on musteri.LOGICALREF=sektorIliski.CSTVNDREF inner join " +
                "LG_INDUSTRY sektor on sektorIliski.INDREF=sektor.LOGICALREF " +
                "where musteri.CODE='" + BayiKodu + "' AND sektorIliski.PRIMARYFLG=1 " +
                ") " +
                "OR @kategoriNumarasi!=38\r\n)";







                SqlDataReader rdBaglantiBakiyeOzeti = cmdBaglantiBakiyeOzeti.ExecuteReader();
                while (rdBaglantiBakiyeOzeti.Read())
                {
                    FiyatListesiBakiye baglanti = new FiyatListesiBakiye();
                    baglanti.siparisTutari = String.Format("{0:N}", Convert.ToDouble(rdBaglantiBakiyeOzeti["SiparisTutari"].ToString()));
                    baglanti.baglantiTutari = String.Format("{0:N}", Convert.ToDouble(rdBaglantiBakiyeOzeti["BaglantiTutari"].ToString()));
                    baglanti.bakiye = String.Format("{0:N}", Convert.ToDouble(rdBaglantiBakiyeOzeti["Bakiye"].ToString()));
                    baglanti.fiyatListesiKodu = rdBaglantiBakiyeOzeti["FiyatListesi"].ToString();
                    baglanti.Aciklama = rdBaglantiBakiyeOzeti["Aciklama"].ToString();
                    baglanti.baglantiLREF = rdBaglantiBakiyeOzeti["BaglantiLREF"].ToString();
                    baglanti.sozlesmeUSD = Convert.ToDouble(rdBaglantiBakiyeOzeti["SabitKurUSD"].ToString());
                    baglanti.sozlesmeEUR = Convert.ToDouble(rdBaglantiBakiyeOzeti["SabitKurEUR"].ToString());
                    //  baglanti.anaGruplar = "";
                    baglanti.iskontoOrani = Convert.ToDouble(rdBaglantiBakiyeOzeti["SozlesmeIskontosu"].ToString().Trim() == "" ? "0" : rdBaglantiBakiyeOzeti["SozlesmeIskontosu"].ToString().Trim());
                    Baglantilar.Add(baglanti);


                }

                con.Close();
            }

            return Baglantilar.OrderBy(x => x.baglantiLREF).ToList();


        }


        [WebMethod]
        public string AnaGruplar(string FiyatListesi, string baglantiLREF, string BayiKodu)
        {
            //string secilebilirAnaGruplar = "";
            //foreach (var item in SecilebilirFiyatListeleri(BayiKodu).Where(x => x.baglantiLREF == baglantiLREF))
            //{
            //    secilebilirAnaGruplar = item.anaGruplar;
            //}

            List<MenuBasliklari> MenuBasliklari = new List<MenuBasliklari>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdMenuBasliklari = new SqlCommand();
                cmdMenuBasliklari.Connection = con;
                cmdMenuBasliklari.CommandText = "";

                cmdMenuBasliklari.CommandText = "SELECT DISTINCT SPECODE, DEFINITION_ FROM LG_" + IzoKaleFirmaNo + "_SPECODES WHERE CODETYPE = 1 AND SPECODETYPE = 1 AND SPETYP1 = 1 "
                + " AND SPECODE like '%KB_%'"
                + " ORDER BY DEFINITION_ ASC";



                SqlDataReader rdMenuBasliklari = cmdMenuBasliklari.ExecuteReader();
                while (rdMenuBasliklari.Read())
                {
                    MenuBasliklari menu = new MenuBasliklari();
                    menu.Success = true;
                    menu.OzelKod = rdMenuBasliklari["SPECODE"].ToString();
                    menu.MenuAdi = rdMenuBasliklari["DEFINITION_"].ToString();
                    menu.AltMenuler = new List<AltMenuBasliklari>();

                    SqlCommand cmdAltMenuBasliklari = new SqlCommand();
                    cmdAltMenuBasliklari.Connection = con;
                    cmdAltMenuBasliklari.CommandText = "SELECT DISTINCT SPECODE, DEFINITION_ FROM LG_" + IzoKaleFirmaNo + "_SPECODES SPS WHERE CODETYPE = 1 AND SPECODETYPE = 1 AND SPETYP2 = 1 "
                    // + " AND SPECODE LIKE '" + menu.OzelKod + "%' AND (SELECT COUNT(*) FROM LG_" + IzoKaleFirmaNo + "_ITEMS WITH (NOLOCK) WHERE SPECODE5 = '" + menu.OzelKod + "' AND SPECODE3 = SPS.SPECODE AND ACTIVE = 0 )>0 "
                    + " AND SPECODE LIKE '" + menu.OzelKod + "%' "
                    + " ORDER BY DEFINITION_ ASC";
                    SqlDataReader rdAltMenuBasliklari = cmdAltMenuBasliklari.ExecuteReader();
                    while (rdAltMenuBasliklari.Read())
                    {
                        AltMenuBasliklari altmenu = new AltMenuBasliklari();
                        altmenu.AltMenuOzelKod = rdAltMenuBasliklari["SPECODE"].ToString();
                        altmenu.AltMenuAdi = rdAltMenuBasliklari["DEFINITION_"].ToString();
                        menu.AltMenuler.Add(altmenu);

                    }


                    MenuBasliklari.Add(menu);
                }
                con.Close();
            }

            return JsonConvert.SerializeObject(MenuBasliklari.OrderBy(x => x.MenuAdi), new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }



        [WebMethod]
        public string HesapEkstresi(string BayiKodu)
        {
            List<HesapEkstresi> HesapEksteListesi = new List<HesapEkstresi>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdHesapEkstresi = new SqlCommand();
                cmdHesapEkstresi.Connection = con;

                cmdHesapEkstresi.CommandText =
                                                     "	   				select  ROW_NUMBER() OVER(ORDER BY VergiNo, Tarih Asc) AS SNo,  * from(										" +
               "	                         SELECT 														" +
               "							 CARI.CODE  CariKodu,								" +
               "							 (CASE WHEN CARI.TAXNR = '' THEN CARI.TCKNO ELSE CARI.TAXNR END) AS VergiNo,								" +
               "	                         SUBSTRING(CARI.DEFINITION_, 1, 30) + ' / ' + CARI.DEFINITION2 Cari, 														" +
               "							 ISNULL(MUSTERI.CODE,'') BayiKodu, 								" +
               "							 ISNULL(MUH.CODE,'') MuhHesabiKodu ,								" +
               "							 ISNULL(MUH.DEFINITION_,'') MuhHesabiAdi,								" +
               "	                         (CASE 														" +
               "	                         when LINE.TRCODE = 1 then 'Nakit Tahsilat' 														" +
               "	                         when LINE.TRCODE = 2 then 'Nakit Ödeme' 														" +
               "	                         when LINE.TRCODE = 3 then 'Borç Dekontu' 														" +
               "	                         when LINE.TRCODE = 4 then 'Alacak Dekontu' 														" +
               "	                         when LINE.TRCODE = 5 then 'Virman Işlemi' 														" +
               "	                         when LINE.TRCODE = 6 then 'Kur Farkı İşlemi' 														" +
               "	                         when LINE.TRCODE = 12 then 'Özel İşlem' 														" +
               "	                         when LINE.TRCODE = 14 then 'Açılış Fişi' 														" +
               "	                         when LINE.TRCODE = 41 then 'Verilen Vade Farkı Faturası' 														" +
               "	                         when LINE.TRCODE = 42 then 'Alınan Vade Farkı Faturası' 														" +
               "	                         when LINE.TRCODE = 45 then 'Verilen Serbest Meslek Makbuzu' 														" +
               "	                         when LINE.TRCODE = 46 then 'Alınan Serbest Meslek Makbuzu' 														" +
               "	                         when LINE.TRCODE = 70 then 'Kredi Kartı Fişi' 														" +
               "	                         when LINE.TRCODE = 71 then 'Kredi Kartı İade Fişi' 														" +
               "	                         when LINE.TRCODE = 72 then 'Firma Kredi Kartı Fişi' 														" +
               "	                         when LINE.TRCODE = 73 then 'Firma Kredi Kartı İade Fişi' 														" +
               "	                         END) BelgeTipi, 														" +
               "							 '' AS SiparisNo,								" +
               "	                         LINE.DATE_ AS Tarih,  														" +
               "	                         LINE.TRANNO AS BelgeNo,  														" +
               "							 '' AS OdemeTipi,								" +
               "	                         (CASE WHEN LINE.SIGN = 0 THEN LINE.AMOUNT ELSE 0 END)  AS Borc, 														" +
               "	                         (CASE WHEN LINE.SIGN = 1 THEN LINE.AMOUNT ELSE 0 END) AS Alacak, 														" +
               "	                         '' AS Aciklama, 														" +
               "	                         LINE.LINEEXP AS Detay 														" +
               "	                         FROM  LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_CLFLINE LINE WITH(NOLOCK) 														" +
               "	                         LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI WITH(NOLOCK) ON LINE.CLIENTREF = CARI.LOGICALREF 														" +
               "	                         LEFT JOIN LG_CVARPASG ILISKI WITH(NOLOCK)  ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo + "														" +
               "	                         LEFT JOIN LG_CSTVND MUSTERI WITH(NOLOCK)  ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 														" +
               "							 LEFT JOIN LG_" + IzoKaleFirmaNo + "_CRDACREF muhILISKI WITH (nOLOCK) ON muhILISKI.CARDREF = CARI.LOGICALREF AND  muhILISKI.TRCODE = 5								" +
               "							 LEFT JOIN LG_" + IzoKaleFirmaNo + "_EMUHACC MUH WITH (NOLOCK) ON muhILISKI.ACCOUNTREF = MUH.LOGICALREF 								" +
               "	                         WHERE LINE.CANCELLED = 0 AND LINE.MODULENR IN (5, 10, 61, 62, 63, 64) AND LINE.TRCODE IN (1, 2, 3, 4, 5, 6, 12, 14, 41, 42, 45, 46, 70, 71, 72, 73)                         						 								" +
               "							 UNION ALL          				   				" +
               "						   SELECT 									" +
               "						    CARI.CODE  CariKodu,									" +
               "							(CASE WHEN CARI.TAXNR = '' THEN CARI.TCKNO ELSE CARI.TAXNR end ) AS VergiNo,								" +
               "	                         SUBSTRING(CARI.DEFINITION_, 1, 30) + ' / ' + CARI.DEFINITION2 Cari, 														" +
               "							 ISNULL(MUSTERI.CODE,'') M2B_BayiKodu, 								" +
               "							 ISNULL(MUH.CODE,'') MuhHesabiKodu ,								" +
               "							 ISNULL(MUH.DEFINITION_,'') MuhHesabiAdi,								" +
               "	                         (CASE  														" +
               "	                         WHEN INV.TRCODE = 1   THEN 'Satınalma Faturası' 														" +
               "	                         WHEN INV.TRCODE = 2   THEN 'Perakende Satış İade Faturası' 														" +
               "	                         WHEN INV.TRCODE = 3   THEN 'Toptan Satış İade Faturası' 														" +
               "	                         WHEN INV.TRCODE = 4   THEN 'Alınan Hizmet Faturası' 														" +
               "	                         WHEN INV.TRCODE = 6   THEN 'Satınalma İade Faturası' 														" +
               "	                         WHEN INV.TRCODE = 7   THEN 'Perakende Satış Faturası' 														" +
               "	                         WHEN INV.TRCODE = 8   THEN 'Toptan Satış Faturası' 														" +
               "	                         WHEN INV.TRCODE = 9   THEN 'Verilen Hizmet Faturası' 														" +
               "	                         WHEN INV.TRCODE = 13  THEN 'Satınalma Fiyat Farkı Faturası' 														" +
               "	                         WHEN INV.TRCODE = 14  THEN 'Satış Fiyat Farkı Faturası' 														" +
               "	                         WHEN INV.TRCODE = 26  THEN 'Müstahsil Makbuzu' 														" +
               "	                         ELSE '??' 														" +
               "	                         END ) as BelgeTipi, 														" +
               "							 (CASE WHEN INV.TRCODE NOT IN (7,8) THEN '' 								" +
               "							      ELSE 								" +
               "									 ISNULL((						" +
               "									 SELECT SIP.FICHENO +',  '						" +
               "										FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_STLINE LINE WITH (NOLOCK) 					" +
               "										LEFT JOIN LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_STFICHE FIS  WITH (NOLOCK) ON LINE.STFICHEREF = FIS.LOGICALREF					" +
               "										LEFT JOIN LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFICHE SIP  WITH (NOLOCK)  ON LINE.ORDFICHEREF = SIP.LOGICALREF					" +
               "										WHERE FIS.INVNO = INV.FICHENO GROUP BY SIP.FICHENO					" +
               "										for XML PATH ('')					" +
               "									 ),'')						" +
               "							 END) AS  SiparisNo,								" +
               "	                         INV.DATE_ AS Tarih,  														" +
               "	                         INV.FICHENO AS BelgeNo, 														" +
               "							 ISNULL(PLN.CODE,'') AS OdemeTipi, 								" +
               "	                         (CASE WHEN INV.TRCODE IN (6, 7, 8, 9) THEN INV.NETTOTAL WHEN INV.TRCODE IN (13, 14) AND INV.DECPRDIFF = 0 THEN INV.NETTOTAL ELSE 0 END) AS Borc, 														" +
               "	                         (CASE WHEN INV.TRCODE IN(1, 2, 3, 4) THEN INV.NETTOTAL  WHEN INV.TRCODE IN(13, 14) AND INV.DECPRDIFF = 1 THEN INV.NETTOTAL ELSE 0 END) AS Alacak, 														" +
               "	                         INV.DOCTRACKINGNR AS Aciklama,  														" +
               "	                         INV.GENEXP1 AS Detay 														" +
               "	                         FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_INVOICE INV WITH(NOLOCK) 														" +
               "	                         LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI WITH(NOLOCK) ON INV.CLIENTREF = CARI.LOGICALREF 														" +
               "	                         LEFT JOIN LG_CVARPASG ILISKI WITH(NOLOCK)  ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO =  " + IzoKaleFirmaNo + "														" +
               "	                         LEFT JOIN LG_CSTVND MUSTERI WITH(NOLOCK)  ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 														" +
               "	                         LEFT JOIN LG_" + IzoKaleFirmaNo + "_CRDACREF muhILISKI ON muhILISKI.CARDREF = CARI.LOGICALREF AND muhILISKI.TRCODE = 5 														" +
               "							 LEFT JOIN LG_" + IzoKaleFirmaNo + "_EMUHACC MUH ON muhILISKI.ACCOUNTREF = MUH.LOGICALREF 								" +
               "							 LEFT JOIN LG_" + IzoKaleFirmaNo + "_PAYPLANS PLN WITH (NOLOCK) ON INV.PAYDEFREF = PLN.LOGICALREF								" +
               "							  WHERE INV.CANCELLED = 0 AND INV.TRCODE IN (1, 2, 3, 4, 6, 7, 8, 9, 13, 14, 26) 								" +
               "	                         UNION ALL 														" +
               "	                         SELECT 														" +
               "							 CARI.CODE  CariKodu,								" +
               "							 (CASE WHEN CARI.TAXNR = '' THEN CARI.TCKNO ELSE CARI.TAXNR END ) AS VergiNo,								" +
               "	                         SUBSTRING(CARI.DEFINITION_, 1, 30) + ' / ' + CARI.DEFINITION2 Cari, 														" +
               "							 ISNULL(MUSTERI.CODE,'') M2B_BayiKodu, 								" +
               "							 ISNULL(MUH.CODE,'') MuhHesabiKodu ,								" +
               "							 ISNULL(MUH.DEFINITION_,'') MuhHesabiAdi,								" +
               "	                         (CASE 														" +
               "	                         WHEN FIS.TRCODE = 3 then 'Gelen Havale/Eft' 														" +
               "	                         WHEN FIS.TRCODE = 4 then 'Gönderilen Havale/Eft' 														" +
               "	                         WHEN FIS.TRCODE = 7 then 'Döviz Alış Belgesi' 														" +
               "	                         WHEN FIS.TRCODE = 8 then 'Döviz Satış Belgesi' 														" +
               "	                         WHEN FIS.TRCODE = 16 then 'Banka Alınan Hizmet Faturası' 														" +
               "	                         WHEN FIS.TRCODE = 17 then 'Banka Verilen Hizmet Faturası' 														" +
               "	                         WHEN FIS.TRCODE = 21 then 'Mustahsil Makbuzu' 														" +
               "	                         ELSE '??' 														" +
               "	                         END) AS BelgeTipi, 														" +
               "							 '' AS SiparisNo,								" +
               "	                         FIS.DATE_ AS Tarih,  														" +
               "	                         FIS.FICHENO AS BelgeNo,  														" +
               "							 '' AS OdemeTipi,								" +
               "	                         (CASE WHEN SATIR.SIGN = 1 THEN AMOUNT ELSE 0 END) AS Borc, 														" +
               "	                         (CASE WHEN SATIR.SIGN = 0 THEN AMOUNT ELSE 0 END) AS Alacak, 														" +
               "	                         (CASE WHEN SATIR.TRANSDUEDATE = SATIR.DATE_ THEN '' ELSE 'Vade: ' + CONVERT(NVARCHAR, SATIR.TRANSDUEDATE, 104) END) AS Aciklama, 														" +
               "	                         SATIR.LINEEXP AS Detay 														" +
               "	                         FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_BNFLINE SATIR WITH(NOLOCK) 														" +
               "	                         LEFT JOIN LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_BNFICHE FIS WITH(NOLOCK) ON SATIR.SOURCEFREF = FIS.LOGICALREF 														" +
               "	                         LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI WITH(NOLOCK) ON SATIR.CLIENTREF = CARI.LOGICALREF 														" +
               "	                         LEFT JOIN LG_CVARPASG ILISKI WITH(NOLOCK)  ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO =  " + IzoKaleFirmaNo + "														" +
               "	                         LEFT JOIN LG_CSTVND MUSTERI WITH(NOLOCK)  ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 														" +
               "							 LEFT JOIN LG_" + IzoKaleFirmaNo + "_CRDACREF muhILISKI WITH (nOLOCK) ON muhILISKI.CARDREF = CARI.LOGICALREF AND  muhILISKI.TRCODE = 5 								" +
               "							 LEFT JOIN LG_" + IzoKaleFirmaNo + "_EMUHACC MUH WITH (NOLOCK) ON muhILISKI.ACCOUNTREF = MUH.LOGICALREF 								" +
               "	                         WHERE SATIR.CANCELLED = 0 AND SATIR.CLIENTREF != 0 AND SATIR.TRANSTYPE = 1 AND FIS.TRCODE IN (3, 4, 7, 8, 16, 17, 21) 														" +
               "	                         UNION ALL 						 								" +
               "	                         SELECT 														" +
               "							 CARI.CODE  CariKodu,								" +
               "							 (CASE WHEN CARI.TAXNR = '' THEN CARI.TCKNO ELSE CARI.TAXNR END ) AS VergiNo,								" +
               "	                         SUBSTRING(CARI.DEFINITION_, 1, 30) + ' / ' + CARI.DEFINITION2 Cari, 														" +
               "							 ISNULL(MUSTERI.CODE,'') M2B_BayiKodu, 								" +
               "							 ISNULL(MUH.CODE,'') MuhHesabiKodu ,								" +
               "							 ISNULL(MUH.DEFINITION_,'') MuhHesabiAdi,								" +
               "	                         (CASE 														" +
               "	                         when ROLL.TRCODE = 1 then 'Çek Girişi' 														" +
               "	                         when ROLL.TRCODE = 2 then 'Senet Girişi' 														" +
               "	                         when ROLL.TRCODE = 3 then 'Çek Çıkışı' 														" +
               "	                         when ROLL.TRCODE = 4 then 'Senet Çıkışı' 														" +
               "	                         END) BelgeTipi, 														" +
               "							 '' AS SiparisNo,								" +
               "	                         ROLL.DATE_ AS Tarih,  														" +
               "	                         ROLL.ROLLNO AS BelgeNo,														" +
               "							 '' AS OdemeTipi,  								" +
               "	                         (CASE WHEN ROLL.TRCODE IN (3, 4) THEN TOTAL ELSE 0 END) AS Borc, 														" +
               "	                         (CASE WHEN ROLL.TRCODE IN(1, 2) THEN TOTAL ELSE 0 END) AS Alacak, 														" +
               "	                         '' AS Aciklama, 														" +
               "	                         ROLL.GENEXP1 + ' ' + ROLL.GENEXP2 AS Detay 														" +
               "	                         FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_CSROLL ROLL WITH(NOLOCK) 														" +
               "	                         LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI WITH(NOLOCK) ON ROLL.CARDREF = CARI.LOGICALREF 														" +
               "	                         LEFT JOIN LG_CVARPASG ILISKI WITH(NOLOCK)  ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO =  " + IzoKaleFirmaNo + "														" +
               "	                         LEFT JOIN LG_CSTVND MUSTERI WITH(NOLOCK)  ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 														" +
               "							 LEFT JOIN LG_" + IzoKaleFirmaNo + "_CRDACREF muhILISKI WITH (nOLOCK) ON muhILISKI.CARDREF = CARI.LOGICALREF AND  muhILISKI.TRCODE = 5								" +
               "							 LEFT JOIN LG_" + IzoKaleFirmaNo + "_EMUHACC MUH WITH (NOLOCK) ON muhILISKI.ACCOUNTREF = MUH.LOGICALREF 								" +
               "	                         WHERE ROLL.CANCELLED = 0 AND ROLL.TRCODE IN (1, 2, 3, 4)                        														" +
               "	) as aa where BayiKodu='" + BayiKodu + "'	order by Tarih asc";



                SqlDataReader rdHesapEkstresi = cmdHesapEkstresi.ExecuteReader();
                double bakiyee = 0;
                while (rdHesapEkstresi.Read())



                {
                    HesapEkstresi ekstre = new HesapEkstresi();
                    ekstre.firma = rdHesapEkstresi["Cari"].ToString();
                    ekstre.Tarih = DateTime.Parse(rdHesapEkstresi["Tarih"].ToString());
                    ekstre.IslemTipi = rdHesapEkstresi["BelgeTipi"].ToString();
                    ekstre.Borc = 0;
                    if (Convert.ToDouble(rdHesapEkstresi["Borc"].ToString()) != 0)
                    {
                        ekstre.Borc = Math.Round(Convert.ToDouble(rdHesapEkstresi["Borc"].ToString()), 2);
                    };

                    ekstre.Alacak = 0;
                    if (Convert.ToDouble(rdHesapEkstresi["Alacak"].ToString()) != 0)
                    {
                        ekstre.Alacak = Math.Round(Convert.ToDouble(rdHesapEkstresi["Alacak"].ToString()), 2);
                    }

                    ekstre.Bakiye = bakiyee + ekstre.Borc - ekstre.Alacak;
                    bakiyee = ekstre.Bakiye;

                    //var aaa = rdHesapEkstresi["Bakiye"].ToString();
                    //if (Convert.ToDouble(rdHesapEkstresi["Bakiye"].ToString()) != 0)
                    //{
                    //    ekstre.Bakiye = Math.Round(Convert.ToDouble(rdHesapEkstresi["Bakiye"].ToString()), 2);
                    //}


                    ekstre.BelgeNo = rdHesapEkstresi["BelgeNo"].ToString();
                    ekstre.OdemeTipi = rdHesapEkstresi["OdemeTipi"].ToString();
                    ekstre.SiparisNo = rdHesapEkstresi["SiparisNo"].ToString();
                    ekstre.Aciklama = rdHesapEkstresi["Aciklama"].ToString();
                    ekstre.Detay = rdHesapEkstresi["Detay"].ToString();
                    HesapEksteListesi.Add(ekstre);
                }

                con.Close();
            }


            return JsonConvert.SerializeObject(HesapEksteListesi, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }




        [WebMethod]
        public string IrsaliyeFisiSatirlari(int stFicheRef)
        {
            List<IrsaliyeSatir> IrsaliyeSatirlari = new List<IrsaliyeSatir>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdIrsaliyeSatir = new SqlCommand();
                cmdIrsaliyeSatir.Connection = con;
                cmdIrsaliyeSatir.CommandText =
                              "SELECT LINE.LOGICALREF as STLINELOGICAREF, "
                                            + " ITEM.CODE as MALZEMEKODU, ITEM.NAME AS MALZEMEADI, LINE.AMOUNT as MIKTAR, SETL.CODE AS BIRIM "
                                            + " FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_STLINE LINE WITH (NOLOCK) "
                                            + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_ITEMS ITEM WITH (NOLOCK) ON LINE.STOCKREF = ITEM.LOGICALREF AND LINE.LINETYPE = 0 "
                                            + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_UNITSETL SETL ON LINE.UOMREF = SETL.LOGICALREF "
                                            + " WHERE LINE.CANCELLED = 0 AND LINE.TRCODE IN (7,8) AND LINE.LINETYPE = 0 AND LINE.STFICHEREF = " + stFicheRef;

                SqlDataReader rdIrsaliyeSatir = cmdIrsaliyeSatir.ExecuteReader();
                while (rdIrsaliyeSatir.Read())
                {
                    IrsaliyeSatir satir = new IrsaliyeSatir();
                    satir.stLineRef = Convert.ToInt32(rdIrsaliyeSatir["STLINELOGICAREF"].ToString());
                    satir.malzemeKodu = rdIrsaliyeSatir["MALZEMEKODU"].ToString();
                    satir.malzemeAdi = rdIrsaliyeSatir["MALZEMEADI"].ToString();
                    satir.miktar = String.Format("{0:N}", Convert.ToDouble(rdIrsaliyeSatir["MIKTAR"].ToString()));
                    satir.birim = rdIrsaliyeSatir["BIRIM"].ToString();
                    IrsaliyeSatirlari.Add(satir);
                }

                con.Close();
            }

            return JsonConvert.SerializeObject(IrsaliyeSatirlari, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }

        [WebMethod]
        public string MusteriyeSevkRaporu(string BayiKodu, string BaslangicTarih, string BitisTarihi)
        {
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdIrsaliyeFis = new SqlCommand();
                cmdIrsaliyeFis.Connection = con;
                cmdIrsaliyeFis.CommandText = "SELECT MUSTERI.TITLE as CARIADI,ITEM.CODE as MALZEMEKODU, ITEM.NAME AS MALZEMEADI,SUM(LINE.AMOUNT) as MIKTAR, SETL.CODE AS BIRIM,ITEM.SPECODE FROM" +
" LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_STFICHE FICHE LEFT JOIN" +
" LG_CVARPASG ILISKI WITH(NOLOCK)  ON ILISKI.ARPREF = FICHE.CLIENTREF AND FIRMNO = " + IzoKaleFirmaNo + " LEFT JOIN" +
" LG_CSTVND MUSTERI WITH(NOLOCK)  ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 LEFT JOIN" +
" LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_STLINE LINE WITH(NOLOCK) ON FICHE.LOGICALREF = LINE.STFICHEREF LEFT JOIN" +
" LG_" + IzoKaleFirmaNo + "_ITEMS ITEM WITH(NOLOCK) ON LINE.STOCKREF = ITEM.LOGICALREF AND LINE.LINETYPE = 0  LEFT JOIN" +
" LG_" + IzoKaleFirmaNo + "_UNITSETL SETL ON LINE.UOMREF = SETL.LOGICALREF" +
" WHERE LINE.CANCELLED = 0 AND LINE.TRCODE IN(7,8) AND LINE.LINETYPE = 0 AND MUSTERI.CODE = '" + BayiKodu + "' AND DOCDATE>= '" + BaslangicTarih + "' AND DOCDATE <= '" + BitisTarihi + "'" +
" group by MUSTERI.CODE,MUSTERI.TITLE,ITEM.CODE,ITEM.NAME,SETL.CODE,ITEM.SPECODE order by SETL.CODE ASC";
                SqlDataReader rdIrsaliyeFis = cmdIrsaliyeFis.ExecuteReader();
                var dt = new DataTable();
                dt.Load(rdIrsaliyeFis);
                con.Close();
                return JsonConvert.SerializeObject(dt, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

            }
        }


        [WebMethod]
        public string IrsaliyeFisleri(string BayiKodu)
        {
            List<IrsaliyeFis> Irsaliyeler = new List<IrsaliyeFis>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdIrsaliyeFis = new SqlCommand();
                cmdIrsaliyeFis.Connection = con;
                cmdIrsaliyeFis.CommandText =
                                " SELECT IRSALIYE.LOGICALREF AS STFICHELOGICALREF, "
                                + " SUBSTRING(CARI.DEFINITION_,1,15) AS cariAdi,  "
                                + " IRSALIYE.DATE_ as irsaliyeTarihi, "
                                + " ISNULL(IRSALIYE.FICHENO, ' - ') as irsaliyeNo, "
                                + " (select top(1) CODE from LG_" + IzoKaleFirmaNo + "_PROJECT where LOGICALREF=IRSALIYE.PROJECTREF) as projeKodu, "
                                + " ISNULL((SELECT TOP 1 DRIVERNAME1+' '+DRIVERSURNAME1+' / '+PLATENUM1+' - '+CHASSISNUM1 FROM  LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_EINVOICEDET WHERE STFREF = IRSALIYE.LOGICALREF ORDER BY LOGICALREF DESC    ),'') AS SOFOR,"

                                + " IRSALIYE.DOCTRACKINGNR AS projeKodu, "
                                //  + " ISNULL(SOZLESME.DOCODE, ' - ') AS baglantiKodu, "
                                + " ISNULL(INV.FICHENO,'-') AS faturaNo, "
                                + " IRSALIYE.GENEXP1 +' '+ IRSALIYE.GENEXP2 +' '+IRSALIYE.GENEXP3 +' '+IRSALIYE.GENEXP4 +' '+ IRSALIYE.GENEXP5 +' '+IRSALIYE.GENEXP6 AS aciklamalar "
                                + " FROM "
                                + " LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_STFICHE IRSALIYE WITH (NOLOCK) "
                                // + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_PURCHOFFER SOZLESME WITH (NOLOCK)  ON IRSALIYE.OFFERREF = SOZLESME.LOGICALREF AND SOZLESME.TRCODE = 1 AND SOZLESME.TYP = 2 AND SOZLESME.CANCELLED = 0 "
                                + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI WITH (NOLOCK)  ON IRSALIYE.CLIENTREF = CARI.LOGICALREF "
                                + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_INVOICE INV WITH (NOLOCK)  ON IRSALIYE.INVOICEREF = INV.LOGICALREF "
                                + " LEFT JOIN LG_CVARPASG ILISKI WITH (NOLOCK)  ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo
                                + " LEFT JOIN LG_CSTVND MUSTERI WITH (NOLOCK)  ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 "

                                + " WHERE IRSALIYE.CANCELLED = 0 AND IRSALIYE.TRCODE IN (7,8) "
                                + " AND MUSTERI.CODE = '" + BayiKodu + "' ";

                cmdIrsaliyeFis.CommandText = cmdIrsaliyeFis.CommandText + " ORDER BY IRSALIYE.DATE_ DESC";
                SqlDataReader rdIrsaliyeFis = cmdIrsaliyeFis.ExecuteReader();
                while (rdIrsaliyeFis.Read())
                {
                    IrsaliyeFis irsaliye = new IrsaliyeFis();
                    irsaliye.stFicheRef = Convert.ToInt32(rdIrsaliyeFis["STFICHELOGICALREF"]);
                    irsaliye.cariAdi = rdIrsaliyeFis["cariAdi"].ToString();
                    irsaliye.irsaliyeTarihi = DateTime.Parse(rdIrsaliyeFis["irsaliyeTarihi"].ToString());
                    irsaliye.irsaliyeNo = rdIrsaliyeFis["irsaliyeNo"].ToString();


                    irsaliye.aciklamalar = rdIrsaliyeFis["aciklamalar"].ToString();
                    irsaliye.fiyatListesi = rdIrsaliyeFis["projeKodu"].ToString();
                    irsaliye.faturaNo = rdIrsaliyeFis["faturaNo"].ToString();



                    Irsaliyeler.Add(irsaliye);
                }

                con.Close();
            }

            return JsonConvert.SerializeObject(Irsaliyeler, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }



        [WebMethod]
        public string SiparisFisiSatirIrsaliyeleri(int orfLineRef)
        {
            List<SiparisSatirIrsaliye> SatirIrsaliyeler = new List<SiparisSatirIrsaliye>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdSiparisSatirIrsaliye = new SqlCommand();
                cmdSiparisSatirIrsaliye.Connection = con;
                cmdSiparisSatirIrsaliye.CommandText =
                              "SELECT LINE.LOGICALREF AS STLINELREF, FIS.FICHENO AS IRSALIYENO, "
                              + " FIS.DATE_ AS IRSALIYETARIHI, "
                              + " LINE.AMOUNT AS MIKTAR, "
                              + " SETL.CODE AS BIRIM, "
                              + " ISNULL(INV.FICHENO,'-') AS FATURANO, "
                              + " FIS.GENEXP1 +' '+FIS.GENEXP2+' '+ FIS.GENEXP3+' '+ FIS.GENEXP4+' '+ FIS.GENEXP5+' '+ FIS.GENEXP6 AS IRSALIYEACIKLAMA  "

                                            + " FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_STLINE LINE WITH (NOLOCK) "
                                            + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_ITEMS ITEM WITH (NOLOCK) ON LINE.STOCKREF = ITEM.LOGICALREF AND LINE.LINETYPE = 0 "
                                            + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_STFICHE FIS WITH (NOLOCK) ON LINE.STFICHEREF = FIS.LOGICALREF "
                                            + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_INVOICE INV WITH (NOLOCK) ON FIS.INVOICEREF = INV.LOGICALREF "
                                            + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_UNITSETL SETL ON LINE.UOMREF = SETL.LOGICALREF "
                                            + " WHERE LINE.CANCELLED = 0 AND LINE.TRCODE IN (7,8) AND LINE.LINETYPE = 0 AND LINE.ORDTRANSREF = " + orfLineRef;

                SqlDataReader rdSiparisSatirIrsaliye = cmdSiparisSatirIrsaliye.ExecuteReader();
                while (rdSiparisSatirIrsaliye.Read())
                {
                    SiparisSatirIrsaliye irsaliye = new SiparisSatirIrsaliye();
                    irsaliye.irsaliyeNo = rdSiparisSatirIrsaliye["IRSALIYENO"].ToString();
                    irsaliye.irsaliyeTarihi = DateTime.Parse(rdSiparisSatirIrsaliye["IRSALIYETARIHI"].ToString());
                    irsaliye.stlineRef = Convert.ToInt32(rdSiparisSatirIrsaliye["STLINELREF"].ToString());
                    irsaliye.miktar = String.Format("{0:N}", Convert.ToDouble(rdSiparisSatirIrsaliye["MIKTAR"].ToString()));
                    irsaliye.birim = rdSiparisSatirIrsaliye["BIRIM"].ToString();
                    irsaliye.FaturaNo = rdSiparisSatirIrsaliye["FATURANO"].ToString();
                    irsaliye.IrsaliyeAciklama = rdSiparisSatirIrsaliye["IRSALIYEACIKLAMA"].ToString();
                    SatirIrsaliyeler.Add(irsaliye);
                }

                con.Close();
            }

            return JsonConvert.SerializeObject(SatirIrsaliyeler, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }



        [WebMethod]
        public string SiparisFisiSatirlari(int OrFicheRef)
        {
            List<SiparisSatir> Satirlar = new List<SiparisSatir>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdSiparisSatir = new SqlCommand();
                cmdSiparisSatir.Connection = con;
                cmdSiparisSatir.CommandText =
                   " SELECT LINE.LOGICALREF as ORFLINELOGICAREF,  "
                                       + "\n      (CASE WHEN LINE.LINETYPE = 0 THEN "
                                       + "\n                 (CASE  WHEN LINE.CLOSED = 1 THEN 'M.Kapalı'  "
                                       + "\n                        WHEN (LINE.SHIPPEDAMOUNT >= LINE.AMOUNT) THEN 'Sevkedilmiş' "
                                       + "\n                        WHEN ((LINE.SHIPPEDAMOUNT > 0) AND (LINE.SHIPPEDAMOUNT < LINE.AMOUNT)) THEN 'Kısmi Sevk'  "
                                       + "\n                        ELSE 'Bekliyor' END) "
                                       + "\n            ELSE '' END) Durum, "

                                       + "\n      (CASE WHEN LINE.LINETYPE = 0 THEN ITEM.CODE "
                                       + "\n            WHEN LINE.LINETYPE = 2 AND GLOBTRANS = 0 THEN 'İndirim' "
                                       + "\n            WHEN LINE.LINETYPE = 3 AND GLOBTRANS = 0 THEN 'Masraf' "
                                       + "\n            WHEN LINE.LINETYPE = 2 AND GLOBTRANS = 1 THEN 'Genel İndirim' "
                                       + "\n            WHEN LINE.LINETYPE = 3 AND GLOBTRANS = 1 THEN 'Genel Masraf' "
                                       + "\n            WHEN LINE.LINETYPE = 4 then'Hizmet' "
                                       + "\n            ELSE '??' END) AS MalzemeKodu, "

                                       + "\n      (CASE WHEN LINE.LINETYPE = 0 THEN ITEM.NAME "
                                       + "\n            WHEN LINE.LINETYPE = 2 THEN LINE.LINEEXP "
                                       + "\n            WHEN LINE.LINETYPE = 3 THEN LINE.LINEEXP "
                                       + "\n            WHEN LINE.LINETYPE = 4 THEN 'NAKLİYE' "
                                       + "\n            ELSE '??' END) AS Aciklama, "

                                       + "\n      (CASE WHEN LINE.LINETYPE = 0 OR LINE.LINETYPE=4 THEN LINE.AMOUNT "
                                       + "\n            WHEN LINE.LINETYPE = 2 THEN FORMAT(LINE.DISCPER, '#0.##') "
                                       + "\n            WHEN LINE.LINETYPE = 3 THEN FORMAT(LINE.DISCPER, '#0.##') "
                                       + "\n            ELSE 0 END) as Miktar,  "

                                       + "\n      (CASE WHEN LINE.LINETYPE = 0 THEN SETL.CODE "
                                       + "\n            WHEN LINE.LINETYPE = 4 THEN 'Nakliye' "
                                       + "\n            WHEN LINE.LINETYPE = 2 THEN '%' "
                                       + "\n            WHEN LINE.LINETYPE = 3 THEN '%' "
                                       + "\n            WHEN LINE.LINETYPE = 4 THEN ''  "
                                       + "\n            ELSE '??' END) AS Birim, "

                                       + "\n      (CASE WHEN LINE.LINETYPE = 0 THEN "
                                       + "\n               (CASE WHEN LINE.CLOSED = 1 THEN 0 "
                                       + "\n                     WHEN (LINE.SHIPPEDAMOUNT >= LINE.AMOUNT) THEN 0  "
                                       + "\n                ELSE (LINE.AMOUNT - LINE.SHIPPEDAMOUNT) END ) "
                                       + "\n       ELSE 0 END) BekleyenMiktar, "


                                       + "\n      (CASE WHEN LINE.LINETYPE = 0 THEN(CASE WHEN LINE.VATINC = 1 THEN LINE.PRICE ELSE (LINE.PRICE*(100 + LINE.VAT)/100) END) "
                                       + "\n            WHEN LINE.LINETYPE = 4 THEN(CASE WHEN LINE.VATINC = 1 THEN LINE.PRICE ELSE (LINE.PRICE*(100 + LINE.VAT)/100) END)  "
                                       + "\n            ELSE 0 END ) AS BirimFiyatKdvDahil, "

                                       + "\n     (CASE WHEN LINE.LINETYPE = 0 OR LINE.LINETYPE = 4 THEN LINE.VAT "
                                       + "\n           ELSE 0 END) AS KDV, "

                                       + "\n      (CASE WHEN LINE.LINETYPE = 0OR LINE.LINETYPE = 4 THEN (CASE WHEN LINE.VATINC = 1 THEN LINE.AMOUNT * LINE.PRICE ELSE LINE.AMOUNT * (LINE.PRICE * (100 + LINE.VAT) /100)  END) "
                                       + "\n            WHEN LINE.LINETYPE = 2 THEN (CASE WHEN LINE.VATINC = 1 THEN TOTAL ELSE  (TOTAL * 1.18)  END) "
                                       + "\n            WHEN LINE.LINETYPE = 3 THEN (CASE WHEN LINE.VATINC = 1 THEN TOTAL ELSE  (TOTAL * 1.18)  END) "
                                       + "\n            ELSE 0 END)  AS Tutar, "

                                       + "\n      (CASE LINE.TRCURR WHEN 0 THEN 'TL' WHEN 20 THEN 'EUR' WHEN 1 THEN 'USD' ELSE '???' END) AS PBirimi "

                                       + "\n      FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFLINE LINE WITH (NOLOCK) "
                                       + "\n      LEFT JOIN LG_" + IzoKaleFirmaNo + "_ITEMS ITEM WITH(NOLOCK) ON LINE.STOCKREF = ITEM.LOGICALREF AND LINE.LINETYPE = 0 "
                                       + "\n      LEFT JOIN LG_" + IzoKaleFirmaNo + "_UNITSETL SETL WITH (NOLOCK) ON LINE.UOMREF = SETL.LOGICALREF "
                                       + "\n      WHERE LINE.CANCELLED = 0 AND LINE.TRCODE = 1 AND LINE.LINETYPE IN(0, 2, 3, 4) "
                                       + "\n      AND LINE.ORDFICHEREF = " + OrFicheRef + " ORDER BY LINE.LINENO_ ";


                SqlDataReader rdSiparisSatir = cmdSiparisSatir.ExecuteReader();
                while (rdSiparisSatir.Read())
                {
                    SiparisSatir satir = new SiparisSatir();
                    satir.orfLineRef = Convert.ToInt32(rdSiparisSatir["ORFLINELOGICAREF"].ToString());

                    satir.durum = rdSiparisSatir["Durum"].ToString();
                    satir.malzemeKodu = rdSiparisSatir["MalzemeKodu"].ToString();
                    satir.Aciklama = rdSiparisSatir["Aciklama"].ToString();
                    satir.miktar = String.Format("{0:N}", Convert.ToDouble(rdSiparisSatir["Miktar"].ToString()));
                    satir.birim = rdSiparisSatir["Birim"].ToString();
                    satir.BekleyenMiktar = String.Format("{0:N}", Convert.ToDouble(rdSiparisSatir["BekleyenMiktar"].ToString()));
                    satir.birimFiyatKdvDahil = String.Format("{0:N}", Convert.ToDouble(rdSiparisSatir["BirimFiyatKdvDahil"].ToString())) + ' ' + rdSiparisSatir["PBirimi"].ToString();

                    satir.Tutar = String.Format("{0:N}", Convert.ToDouble(rdSiparisSatir["Tutar"].ToString())) + ' ' + rdSiparisSatir["PBirimi"].ToString();
                    Satirlar.Add(satir);

                }

                con.Close();
            }

            return JsonConvert.SerializeObject(Satirlar, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }




        [WebMethod]
        public string SiparisFisleri(string BayiKodu)
        {
            List<SiparisFis> Siparisler = new List<SiparisFis>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdSiparisFis = new SqlCommand();
                cmdSiparisFis.Connection = con;
                cmdSiparisFis.CommandText = "SELECT * FROM ( "
                                + " SELECT SIPARIS.LOGICALREF AS ORFICHELOGICALREF, "
                                //   + " (CASE WHEN SIPARIS.STATUS = 1 THEN 'Onay Bekliyor %'+CAST(FLOOR(ISNULL(SIPARISKAPAMA.KAPANAN,0)*100/SIPARIS.NETTOTAL) AS VARCHAR) ELSE '' END) Durum, "
                                + " CARI.DEFINITION_ AS cariAdi,  "
                                + " SIPARIS.DATE_ as siparisTarihi, "
                                + " ISNULL(SIPARIS.FICHENO, ' - ') as siparisNo, "
                                + " ISNULL(SIPARIS.CUSTORDNO, ' - ') as portalKodu, "
                                // + " SIPARIS.DOCTRACKINGNR AS projeKodu, "
                                + " (select top(1) CODE from LG_" + IzoKaleFirmaNo + "_PROJECT where LOGICALREF=SIPARIS.PROJECTREF) as projeKodu, "
                                + "(select top(1) cast(cast(LDATA As varbinary(MAX)) as varchar(MAX)) from LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_PERDOC where INFOREF=SIPARIS.LOGICALREF and INFOTYP=5 and SIPARIS.DATE_>'2023-06-08') as adresBasligi,"
                                //  + " ISNULL(SOZLESME.DOCODE, ' - ') AS baglantiKodu, "

                                + " (CASE WHEN ( (SELECT COUNT(*)  FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFLINE WHERE (LINETYPE = 0) AND (CANCELLED = 0) AND ((CLOSED = 1) OR (SHIPPEDAMOUNT>=AMOUNT)) AND ORDFICHEREF = SIPARIS.LOGICALREF ) = (SELECT COUNT(*)  FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFLINE WHERE (LINETYPE = 0) AND (CANCELLED = 0) AND ORDFICHEREF = SIPARIS.LOGICALREF ) ) THEN 'Sevkedilmiş' "
                                + "       WHEN ( (SELECT COUNT(*)  FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFLINE WHERE (LINETYPE = 0) AND (CANCELLED = 0) AND (CLOSED = 0) AND (SHIPPEDAMOUNT = 0) AND ORDFICHEREF = SIPARIS.LOGICALREF )     = (SELECT COUNT(*)  FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFLINE WHERE (LINETYPE = 0) AND (CANCELLED = 0) AND ORDFICHEREF = SIPARIS.LOGICALREF ) ) THEN 'Bekliyor' "
                                + "       ELSE 'Kısmi Sevk' END) AS SIPARISDURUMU, "
                                + " SIPARIS.GENEXP1 +' '+ SIPARIS.GENEXP2 +' '+SIPARIS.GENEXP3 +' '+SIPARIS.GENEXP4 +' '+ SIPARIS.GENEXP5 +' '+SIPARIS.GENEXP6 AS aciklamalar, "
                                + " (CASE SIPARIS.TRCURR WHEN 0 THEN 'TL' WHEN 20 THEN 'EUR' WHEN 1 THEN 'USD' ELSE '???' END) AS PARABIRIMI, "
                                + "  ISNULL((SELECT SUM((CASE WHEN CLOSED = 1 THEN AMOUNT ELSE AMOUNT END) * (LINENET / AMOUNT) * (100 + VAT) / 100) FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFLINE  WITH (NOLOCK) WHERE (LINETYPE = 0 OR LINETYPE = 4) AND CANCELLED = 0 AND ORDFICHEREF = SIPARIS.LOGICALREF),0) AS SiparisTutari, "
                                + "  ISNULL((SELECT SUM((LINENET) * (100 + VAT) / 100)   FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_STLINE  WITH (NOLOCK) WHERE  ORDFICHEREF = SIPARIS.LOGICALREF AND CANCELLED = 0 ),0) AS SevkedilenTutar "

                            + " FROM "
                                + " LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFICHE SIPARIS WITH (NOLOCK) "
                                //  + " LEFT JOIN LV_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_PAYTRANSSUM SIPARISKAPAMA WITH (NOLOCK)  ON SIPARISKAPAMA.FICHEREF = SIPARIS.LOGICALREF  "
                                //  + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_PURCHOFFER SOZLESME WITH (NOLOCK)  ON SIPARIS.OFFERREF = SOZLESME.LOGICALREF AND SOZLESME.TRCODE = 1 AND SOZLESME.TYP = 2 AND SOZLESME.CANCELLED = 0 "
                                + " LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI WITH (NOLOCK)  ON SIPARIS.CLIENTREF = CARI.LOGICALREF "
                                + " LEFT JOIN LG_CVARPASG ILISKI WITH (NOLOCK)  ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo
                                + " LEFT JOIN LG_CSTVND MUSTERI WITH (NOLOCK)  ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 "
                                + " WHERE SIPARIS.CANCELLED = 0 AND SIPARIS.STATUS != 2 AND SIPARIS.TRCODE = 1 "
                                + " AND MUSTERI.CODE = '" + BayiKodu + "' ";

                cmdSiparisFis.CommandText = cmdSiparisFis.CommandText + " ) AS TUMSORGU";



                cmdSiparisFis.CommandText = cmdSiparisFis.CommandText + " ORDER BY siparisTarihi DESC";
                SqlDataReader rdSiparisFis = cmdSiparisFis.ExecuteReader();
                while (rdSiparisFis.Read())
                {
                    SiparisFis siparis = new SiparisFis();
                    siparis.orFicheRef = Convert.ToInt32(rdSiparisFis["ORFICHELOGICALREF"]);
                    siparis.cariAdi = rdSiparisFis["cariAdi"].ToString();
                    siparis.siparisDurumu = rdSiparisFis["SIPARISDURUMU"].ToString();
                    siparis.siparisTarihi = DateTime.Parse(rdSiparisFis["siparisTarihi"].ToString());
                    siparis.siparisNo = rdSiparisFis["siparisNo"].ToString();
                    siparis.adresBasligi = rdSiparisFis["adresBasligi"].ToString().Trim();
                    siparis.portalKodu = rdSiparisFis["portalKodu"].ToString();
                    // siparis.projeKodu = rdSiparisFis["projeKodu"].ToString();
                    siparis.fiyatListesi = rdSiparisFis["projeKodu"].ToString();

                    //siparis.Statu = rdSiparisFis["Durum"].ToString();
                    siparis.aciklamalar = rdSiparisFis["aciklamalar"].ToString().Trim();
                    siparis.siparisTutari = String.Format("{0:N}", Convert.ToDouble(rdSiparisFis["SiparisTutari"].ToString())) + ' ' + rdSiparisFis["PARABIRIMI"].ToString();
                    siparis.sevkedilenTutar = String.Format("{0:N}", Convert.ToDouble(rdSiparisFis["SevkedilenTutar"].ToString())) + ' ' + rdSiparisFis["PARABIRIMI"].ToString();
                    // siparis.PlanVarmi = Int16.Parse(rdSiparisFis["PlanVarmi"].ToString());

                    Siparisler.Add(siparis);
                }

                con.Close();
            }

            return JsonConvert.SerializeObject(Siparisler, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }
        [WebMethod]
        public string TumBayilerinBaglantiBakiyeOzeti()
        {
            List<TumBayilerBaglantiBakiyeOzeti> Baglantilar = new List<TumBayilerBaglantiBakiyeOzeti>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();



                SqlCommand cmdBaglantiBakiyeOzeti = new SqlCommand();
                cmdBaglantiBakiyeOzeti.Connection = con;
                cmdBaglantiBakiyeOzeti.CommandText =
                   " SELECT MusteriKodu, MusteriAdi, BaglantiLREF,  FiyatListesi,  "
               + "\n  (CASE WHEN BaglantiLREF = 0 THEN 'Liste'"
               + "\n  WHEN BaglantiLREF != 0 THEN 'Bağlantı'"
               + "\n  ELSE '' END) as Aciklama,"
               + "\n     BaglantiTutari, SiparisTutari, Bakiye,SozlesmeIskontosu,ListeIskontosu, "
               + "\n     (CASE WHEN BaglantiLREF = 0 THEN 0 WHEN BaglantiLREF != 0 THEN (select BaseTopFiyat+(BaseTopFiyat*KDV)/100 as KdvDahilFiyat from (select TOP(1) ITEM.VAT as KDV, (SELECT TOP 1 PRICE    FROM LG_" + IzoKaleFirmaNo + "_PRCLIST WITH(NOLOCK) WHERE PTYPE = 2 AND CARDREF = ITEM.LOGICALREF AND INCVAT = 0 AND DEFINITION_ = FiyatListesi) AS BaseTopFiyat from LG_" + IzoKaleFirmaNo + "_ITEMS ITEM LEFT JOIN LG_" + IzoKaleFirmaNo + "_UNITSETF UNITA  WITH (NOLOCK) ON UNITA.LOGICALREF = ITEM.UNITSETREF WHERE(ITEM.ACTIVE = 0)   AND ITEM.CODE IN('1520019') AND ITEM.SPECODE5='FLOW') TEMP) end) as BLC19Fiyati "

               + "\n     FROM "
               + "\n     ( "
               + "\n          SELECT "

               + "\n          MusteriKodu, MusteriAdi, BaglantiLREF, FiyatListesi, "
               + "\n          MAX(Aciklama) as Aciklama, "
               //    + "\n          ISNULL(CONVERT(VARCHAR, (ISNULL(MAX(SabitKurTarihi), 0)), 104), '') AS SabitKurTarihi, "
               + "\n          MAX(SabitKurUSD) as SabitKurUSD, "
               + "\n          MAX(SabitKurEUR) AS SabitKurEUR, "
               + "\n          SUM(BaglantiTutari) AS BaglantiTutari, "
               + "\n          SUM(SiparisTutari) AS SiparisTutari, "
               + "\n          (CASE WHEN SUM(BaglantiTutari) = 0 THEN 0  ELSE SUM(BaglantiTutari) - SUM(SiparisTutari)  END) as Bakiye,SozlesmeIskontosu,ListeIskontosu "


               + "\n          FROM "
               + "\n          ( "


               + "\n                  SELECT "
               + "\n                  'Sipariş ' AS Tip, "
               + "\n                  ISNULL(MUSTERI.CODE, '-') AS MusteriKodu, "
               + "\n                  ISNULL(MUSTERI.TITLE, '!! MÜŞTERİYE BAĞLANMAMIŞ !!') AS MusteriAdi, "
               + "\n                  (select NAME from LG_" + IzoKaleFirmaNo + "_PROJECT where LOGICALREF=ISNULL(SOZLESME.PROJECTREF, -1)) AS FiyatListesi, "
               + "\n                  0 AS BaglantiTutari, "
               + "\n                  (SELECT SUM((CASE WHEN CLOSED = 1 THEN AMOUNT ELSE AMOUNT END) * (LINENET / AMOUNT) * (100 + VAT) / 100) FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFLINE WHERE (LINETYPE = 0 OR LINETYPE = 4) AND CANCELLED = 0 AND ORDFICHEREF = SIPARIS.LOGICALREF) AS SiparisTutari, "
               + "\n                  ISNULL(SOZLESME.LOGICALREF, 0) AS BaglantiLREF, "
               + "\n                   ISNULL((SELECT TEXTFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),'') AS Aciklama, "
               //  + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurTarihi, "
               + "\n                   ISNULL((SELECT NUMFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurUSD, "
               + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurEUR, "
               + "\n                   (select top(1) SPECODE from LG_" + IzoKaleFirmaNo + "_PURCHOFFERLN where ORDFICHEREF=SOZLESME.LOGICALREF order by SPECODE desc) as SozlesmeIskontosu,  "
               + "\n                   (CASE WHEN ISNULL(SOZLESME.LOGICALREF, 0)!=0 THEN 0 ELSE (select top(1) DISCRATE from LG_" + IzoKaleFirmaNo + "_CLCARD where CODE=MUSTERI.CODE) END) as ListeIskontosu  "

               + "\n                  FROM "
               + "\n                  LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFICHE SIPARIS "
               + "\n                   LEFT JOIN LG_" + IzoKaleFirmaNo + "_PURCHOFFER SOZLESME ON SIPARIS.OFFERREF = SOZLESME.LOGICALREF AND SOZLESME.TRCODE = 1 AND SOZLESME.TYP = 2 AND SOZLESME.CANCELLED = 0 "
               + "\n                    LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI ON SIPARIS.CLIENTREF = CARI.LOGICALREF "
               + "\n                     LEFT JOIN LG_CVARPASG ILISKI ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo + " "
               + "\n                      LEFT JOIN LG_CSTVND MUSTERI ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 "
               + "\n                  WHERE SIPARIS.CANCELLED = 0 AND SIPARIS.STATUS != 2 AND SIPARIS.TRCODE = 1 "


               + "\n                  UNION ALL "


               + "\n                  SELECT "
               + "\n                  'Sözleşme' AS Tip, "
               + "\n                  ISNULL(MUSTERI.CODE, '-') AS MusteriKodu, "
               + "\n                  ISNULL(MUSTERI.TITLE, '!! MÜŞTERİYE BAĞLANMAMIŞ !!') AS MusteriAdi,  "
               + "\n                  (select NAME from LG_" + IzoKaleFirmaNo + "_PROJECT where LOGICALREF=ISNULL(SOZLESME.PROJECTREF, -1)) AS FiyatListesi, "
               + "\n                  ISNULL(SOZLESME.NETTOTAL, 0) AS BaglantiTutari, "
               + "\n                  0 AS SiparisTutari, "
               + "\n                  ISNULL(SOZLESME.LOGICALREF, 0) AS BaglantiLREF, "
               + "\n                   ISNULL((SELECT TEXTFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),'') AS Aciklama, "
               //   + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurTarihi,"
               + "\n                   ISNULL((SELECT NUMFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurUSD, "
               + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurEUR, "
               + "\n                   (select top(1) SPECODE from LG_" + IzoKaleFirmaNo + "_PURCHOFFERLN where ORDFICHEREF=SOZLESME.LOGICALREF order by SPECODE desc) as SozlesmeIskontosu, "
               + "\n                   '0' as ListeIskontosu "

               + "\n                  FROM "
               + "\n                    LG_" + IzoKaleFirmaNo + "_PURCHOFFER SOZLESME  "
               + "\n                     LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI ON SOZLESME.CLIENTREF = CARI.LOGICALREF "
               + "\n                      LEFT JOIN LG_CVARPASG ILISKI ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo + " "
               + "\n                       LEFT JOIN LG_CSTVND MUSTERI ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 "
               + "\n                  WHERE SOZLESME.TRCODE = 1 AND SOZLESME.TYP = 2 AND SOZLESME.CANCELLED = 0 "

               + "\n          ) AS AA  GROUP BY MusteriKodu,MusteriAdi, FiyatListesi , BaglantiLREF,SozlesmeIskontosu,ListeIskontosu "

               + "\n     ) AS SASAS "
               + "\n     WHERE MusteriKodu in (SELECT distinct(BayiKodu) FROM IZOKALEPORTAL.dbo.BayiKullanicilari)  "

               + "\n     ORDER BY MusteriAdi ASC ";



                SqlDataReader rdBaglantiBakiyeOzeti = cmdBaglantiBakiyeOzeti.ExecuteReader();
                while (rdBaglantiBakiyeOzeti.Read())
                {

                    double BLC19Fiyati = Convert.ToDouble((rdBaglantiBakiyeOzeti["BLC19Fiyati"].ToString() == "" ? "0" : rdBaglantiBakiyeOzeti["BLC19Fiyati"].ToString()).Replace(".", ","));
                    TumBayilerBaglantiBakiyeOzeti baglanti = new TumBayilerBaglantiBakiyeOzeti();
                    baglanti.siparisTutari = String.Format("{0:N}", Convert.ToDouble(rdBaglantiBakiyeOzeti["SiparisTutari"].ToString())) + " TL";
                    baglanti.baglantiTutari = String.Format("{0:N}", Convert.ToDouble(rdBaglantiBakiyeOzeti["BaglantiTutari"].ToString())) + " TL";
                    baglanti.bakiye = String.Format("{0:N}", Convert.ToDouble(rdBaglantiBakiyeOzeti["Bakiye"].ToString())) + " TL";
                    baglanti.siparisTutariDouble = Math.Round(Convert.ToDouble(rdBaglantiBakiyeOzeti["SiparisTutari"].ToString()), 2);
                    baglanti.baglantiTutariDouble = Math.Round(Convert.ToDouble(rdBaglantiBakiyeOzeti["BaglantiTutari"].ToString()), 2);
                    baglanti.bakiyeDouble = Math.Round(Convert.ToDouble(rdBaglantiBakiyeOzeti["Bakiye"].ToString()), 2);
                    baglanti.fiyatListesiKodu = rdBaglantiBakiyeOzeti["FiyatListesi"].ToString();
                    baglanti.Aciklama = rdBaglantiBakiyeOzeti["Aciklama"].ToString();
                    baglanti.baglantiLREF = rdBaglantiBakiyeOzeti["BaglantiLREF"].ToString();
                    baglanti.iskontoOrani = Convert.ToDouble(rdBaglantiBakiyeOzeti["SozlesmeIskontosu"].ToString().Trim() == "" ? "0" : rdBaglantiBakiyeOzeti["SozlesmeIskontosu"].ToString().Trim());
                    baglanti.ListeIskontosu = Convert.ToDouble(rdBaglantiBakiyeOzeti["ListeIskontosu"].ToString().Trim() == "" ? "0" : rdBaglantiBakiyeOzeti["ListeIskontosu"].ToString().Trim());
                    baglanti.MusteriAdi = rdBaglantiBakiyeOzeti["MusteriAdi"].ToString();
                    baglanti.MusteriKodu = rdBaglantiBakiyeOzeti["MusteriKodu"].ToString();
                    baglanti.kalanAdetDouble = baglanti.bakiyeDouble == 0 ? 0 : (baglanti.baglantiLREF == "0") ? 0 : (BLC19Fiyati == 0) ? 0 : Convert.ToInt32(baglanti.bakiyeDouble / (BLC19Fiyati - (BLC19Fiyati * baglanti.iskontoOrani / 100)));
                    baglanti.kalanAdet = String.Format("{0:N}", baglanti.kalanAdetDouble);

                    Baglantilar.Add(baglanti);
                }

                con.Close();
            }

            return JsonConvert.SerializeObject(Baglantilar, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }
        [WebMethod]
        public List<SozlesmeVeCarileri> SozlesmeyeBagliCarilerVeSatisElemanlari()
        {
            List<SozlesmeVeCarileri> Baglantilar = new List<SozlesmeVeCarileri>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdBaglantiBakiyeOzeti = new SqlCommand();
                cmdBaglantiBakiyeOzeti.Connection = con;
                cmdBaglantiBakiyeOzeti.CommandText = "select sozlesme.LOGICALREF as baglantiLREF,cari.LOGICALREF as cariLREF, cari.CODE,cari.DEFINITION_,cari.SPECODE from LG_" + IzoKaleFirmaNo + "_PURCHOFFER sozlesme left join LG_" + IzoKaleFirmaNo + "_CLCARD cari on sozlesme.CLIENTREF=cari.LOGICALREF";
                SqlDataReader rdBaglantiBakiyeOzeti = cmdBaglantiBakiyeOzeti.ExecuteReader();
                while (rdBaglantiBakiyeOzeti.Read())
                {
                    SozlesmeVeCarileri baglanti = new SozlesmeVeCarileri();
                    baglanti.CariAdi = rdBaglantiBakiyeOzeti["DEFINITION_"].ToString();
                    baglanti.CariKodu = rdBaglantiBakiyeOzeti["CODE"].ToString();
                    baglanti.SatisElemani = rdBaglantiBakiyeOzeti["SPECODE"].ToString();
                    baglanti.baglantiLREF = Convert.ToInt32(rdBaglantiBakiyeOzeti["baglantiLREF"].ToString());
                    baglanti.cariLREF = Convert.ToInt32(rdBaglantiBakiyeOzeti["cariLREF"].ToString());

                    Baglantilar.Add(baglanti);
                }

                con.Close();
            }
            return Baglantilar;
        }
        [WebMethod]
        public string BaglantiBakiyeOzeti(string BayiKodu)
        {
            List<FiyatListesiBakiye> Baglantilar = new List<FiyatListesiBakiye>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdBaglantiBakiyeOzeti = new SqlCommand();
                cmdBaglantiBakiyeOzeti.Connection = con;
                cmdBaglantiBakiyeOzeti.CommandText =
                   " SELECT MusteriKodu, MusteriAdi, BaglantiLREF,  FiyatListesi,  "
               + "\n  (CASE WHEN BaglantiLREF = 0 THEN 'Liste'"
               + "\n  WHEN BaglantiLREF != 0 AND BaglantiTutari > 1 THEN 'Bağlantı'"
               + "\n  ELSE '' END) as Aciklama,"
               + "\n     BaglantiTutari, SiparisTutari, Bakiye,SozlesmeIskontosu "

               + "\n     FROM "
               + "\n     ( "
               + "\n          SELECT "

               + "\n          MusteriKodu, MusteriAdi, BaglantiLREF, FiyatListesi, "
               + "\n          MAX(Aciklama) as Aciklama, "
               //       + "\n          ISNULL(CONVERT(VARCHAR, (ISNULL(MAX(SabitKurTarihi), 0)), 104), '') AS SabitKurTarihi, "
               + "\n          MAX(SabitKurUSD) as SabitKurUSD, "
               + "\n          MAX(SabitKurEUR) AS SabitKurEUR, "
               + "\n          SUM(BaglantiTutari) AS BaglantiTutari, "
               + "\n          SUM(SiparisTutari) AS SiparisTutari, "
               + "\n          (CASE WHEN SUM(BaglantiTutari) = 0 THEN 0  ELSE SUM(BaglantiTutari) - SUM(SiparisTutari)  END) as Bakiye,SozlesmeIskontosu "


               + "\n          FROM "
               + "\n          ( "


               + "\n                  SELECT "
               + "\n                  'Sipariş ' AS Tip, "
               + "\n                  ISNULL(MUSTERI.CODE, '-') AS MusteriKodu, "
               + "\n                  ISNULL(MUSTERI.TITLE, '!! MÜŞTERİYE BAĞLANMAMIŞ !!') AS MusteriAdi, "
               + "\n                  (select NAME from LG_" + IzoKaleFirmaNo + "_PROJECT where LOGICALREF=ISNULL(SIPARIS.PROJECTREF, -1)) AS FiyatListesi, "
               + "\n                  0 AS BaglantiTutari, "
               + "\n                  (SELECT SUM(LINENET+VATAMNT) FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFLINE WHERE (LINETYPE = 0 OR LINETYPE = 4) AND CANCELLED = 0 AND ORDFICHEREF = SIPARIS.LOGICALREF) AS SiparisTutari, "
               + "\n                  ISNULL(SOZLESME.LOGICALREF, 0) AS BaglantiLREF, "
               + "\n                   ISNULL((SELECT TEXTFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),'') AS Aciklama, "
               //      + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurTarihi, "
               + "\n                   ISNULL((SELECT NUMFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurUSD, "
               + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurEUR, "
               + "\n                   (select top(1) SPECODE from LG_" + IzoKaleFirmaNo + "_PURCHOFFERLN where ORDFICHEREF=SOZLESME.LOGICALREF order by SPECODE desc) as SozlesmeIskontosu  "

               + "\n                  FROM "
               + "\n                  LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFICHE SIPARIS "
               + "\n                   LEFT JOIN LG_" + IzoKaleFirmaNo + "_PURCHOFFER SOZLESME ON SIPARIS.OFFERREF = SOZLESME.LOGICALREF AND SOZLESME.TRCODE = 1 AND SOZLESME.TYP = 2 AND SOZLESME.CANCELLED = 0 "
               + "\n                    LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI ON SIPARIS.CLIENTREF = CARI.LOGICALREF "
               + "\n                     LEFT JOIN LG_CVARPASG ILISKI ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo + " "
               + "\n                      LEFT JOIN LG_CSTVND MUSTERI ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 "
               + "\n                  WHERE SIPARIS.CANCELLED = 0 AND SIPARIS.STATUS != 2 AND SIPARIS.TRCODE = 1 AND MUSTERI.CODE = '" + BayiKodu + "' "


               + "\n                  UNION ALL "


               + "\n                  SELECT "
               + "\n                  'Sözleşme' AS Tip, "
               + "\n                  ISNULL(MUSTERI.CODE, '-') AS MusteriKodu, "
               + "\n                  ISNULL(MUSTERI.TITLE, '!! MÜŞTERİYE BAĞLANMAMIŞ !!') AS MusteriAdi,  "
               + "\n                  (select NAME from LG_" + IzoKaleFirmaNo + "_PROJECT where LOGICALREF=ISNULL(SOZLESME.PROJECTREF, -1)) AS FiyatListesi, "
               + "\n                  ISNULL(SOZLESME.NETTOTAL, 0) AS BaglantiTutari, "
               + "\n                  0 AS SiparisTutari, "
               + "\n                  ISNULL(SOZLESME.LOGICALREF, 0) AS BaglantiLREF, "
               + "\n                   ISNULL((SELECT TEXTFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),'') AS Aciklama, "
               //   + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurTarihi,"
               + "\n                   ISNULL((SELECT NUMFLDS1 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurUSD, "
               + "\n                   ISNULL((SELECT NUMFLDS2 FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_DEFNFLDSTRANV WHERE PARENTREF = SOZLESME.LOGICALREF AND MODULENR = 262 AND LEVEL_ = 0),0) AS SabitKurEUR, "
               + "\n                   (select top(1) SPECODE from LG_" + IzoKaleFirmaNo + "_PURCHOFFERLN where ORDFICHEREF=SOZLESME.LOGICALREF order by SPECODE desc) as SozlesmeIskontosu "

               + "\n                  FROM "
               + "\n                    LG_" + IzoKaleFirmaNo + "_PURCHOFFER SOZLESME  "
               + "\n                     LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI ON SOZLESME.CLIENTREF = CARI.LOGICALREF "
               + "\n                      LEFT JOIN LG_CVARPASG ILISKI ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo + " "
               + "\n                       LEFT JOIN LG_CSTVND MUSTERI ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 "
               + "\n                  WHERE SOZLESME.TRCODE = 1 AND SOZLESME.TYP = 2 AND SOZLESME.CANCELLED = 0 AND MUSTERI.CODE = '" + BayiKodu + "' "

               + "\n          ) AS AA  GROUP BY MusteriKodu,MusteriAdi, FiyatListesi , BaglantiLREF,SozlesmeIskontosu "

               + "\n     ) AS SASAS "
               + "\n     WHERE(BaglantiTutari > 1) OR(SiparisTutari > 1) "

               + "\n     ORDER BY FiyatListesi DESC ";



                SqlDataReader rdBaglantiBakiyeOzeti = cmdBaglantiBakiyeOzeti.ExecuteReader();
                while (rdBaglantiBakiyeOzeti.Read())
                {
                    FiyatListesiBakiye baglanti = new FiyatListesiBakiye();
                    baglanti.siparisTutari = String.Format("{0:N}", Convert.ToDouble(rdBaglantiBakiyeOzeti["SiparisTutari"].ToString())) + " TL";
                    baglanti.baglantiTutari = String.Format("{0:N}", Convert.ToDouble(rdBaglantiBakiyeOzeti["BaglantiTutari"].ToString())) + " TL";
                    baglanti.bakiye = String.Format("{0:N}", Convert.ToDouble(rdBaglantiBakiyeOzeti["Bakiye"].ToString())) + " TL";
                    baglanti.fiyatListesiKodu = rdBaglantiBakiyeOzeti["FiyatListesi"].ToString();
                    baglanti.Aciklama = rdBaglantiBakiyeOzeti["Aciklama"].ToString();
                    baglanti.baglantiLREF = rdBaglantiBakiyeOzeti["BaglantiLREF"].ToString();

                    baglanti.iskontoOrani = Convert.ToDouble(rdBaglantiBakiyeOzeti["SozlesmeIskontosu"].ToString().Trim() == "" ? "0" : rdBaglantiBakiyeOzeti["SozlesmeIskontosu"].ToString().Trim());

                    Baglantilar.Add(baglanti);
                }

                con.Close();
            }

            return JsonConvert.SerializeObject(Baglantilar, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }



        [WebMethod]
        public string HesapOzeti(string BayiKodu)
        {
            List<HesapOzeti> HesapOzetiListesi = new List<HesapOzeti>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdHesapOzeti = new SqlCommand();
                cmdHesapOzeti.Connection = con;
                cmdHesapOzeti.CommandText =


                    " SELECT MusteriKodu, Kodu, Unvani, Aciklama, ISNULL(Sum(Borc), 0) Borc, ISNULL(Sum(Alacak), 0) Alacak, (ISNULL(Sum(Borc), 0) - ISNULL(Sum(Alacak), 0)) as Bakiye "

                    + " FROM( "
                    + "    SELECT MUSTERI.CODE MusteriKodu, CARI.CODE AS Kodu, SUBSTRING(CARI.DEFINITION_,1,18)+'..' AS Unvani, CARI.DEFINITION2 Aciklama,"
                    + "        (CASE LINE.SIGN WHEN 0 THEN AMOUNT ELSE 0 END) Borc,  "
                    + "        (CASE LINE.SIGN WHEN 1 THEN AMOUNT ELSE 0 END) Alacak "
                    + "        FROM LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_CLFLINE LINE "
                    + "        LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI WITH(NOLOCK)  ON LINE.CLIENTREF = CARI.LOGICALREF "
                    + "        LEFT JOIN LG_CVARPASG ILISKI WITH(NOLOCK)  ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo
                    + "        LEFT JOIN LG_CSTVND MUSTERI WITH(NOLOCK)  ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 "
                    + "     WHERE LINE.CANCELLED = 0 AND MUSTERI.CODE = '" + BayiKodu + "' "
                    + " ) AS aa "
                    + " GROUP BY MusteriKodu, Kodu, Unvani, Aciklama ";

                SqlDataReader rdHesapOzeti = cmdHesapOzeti.ExecuteReader();
                while (rdHesapOzeti.Read())
                {
                    HesapOzeti Ozet = new HesapOzeti();
                    Ozet.Kodu = rdHesapOzeti["Kodu"].ToString();
                    Ozet.Unvani = rdHesapOzeti["Unvani"].ToString();
                    Ozet.Aciklama = rdHesapOzeti["Aciklama"].ToString();

                    Ozet.Borc = "";
                    if ((Convert.ToDouble(rdHesapOzeti["Borc"].ToString()) < -0.9) || (Convert.ToDouble(rdHesapOzeti["Borc"].ToString()) > 0.9))
                    {
                        Ozet.Borc = String.Format("{0:N}", Convert.ToDouble(rdHesapOzeti["Borc"].ToString())) + " TL";
                    };

                    Ozet.Alacak = "";
                    if ((Convert.ToDouble(rdHesapOzeti["Alacak"].ToString()) < -0.9) || (Convert.ToDouble(rdHesapOzeti["Alacak"].ToString()) > 0.9))
                    {
                        Ozet.Alacak = String.Format("{0:N}", Convert.ToDouble(rdHesapOzeti["Alacak"].ToString())) + " TL";
                    }

                    Ozet.Bakiye = "";
                    if ((Convert.ToDouble(rdHesapOzeti["Bakiye"].ToString()) < -0.9) || (Convert.ToDouble(rdHesapOzeti["Bakiye"].ToString()) > 0.9))
                    {
                        Ozet.Bakiye = String.Format("{0:N}", Math.Abs(Convert.ToDouble(rdHesapOzeti["Bakiye"].ToString()))) + " TL";


                        if (Convert.ToDouble(rdHesapOzeti["Bakiye"].ToString()) < 0)
                        {
                            Ozet.Bakiye = Ozet.Bakiye + " (A)";
                        }
                        else
                        {
                            Ozet.Bakiye = Ozet.Bakiye + " (B)";
                        }

                    }


                    HesapOzetiListesi.Add(Ozet);
                }

                con.Close();
            }


            return JsonConvert.SerializeObject(HesapOzetiListesi, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }


        [WebMethod]
        public string MusteriyeBagliCariBilgileri(string BayiKodu)
        {
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmdHesapOzeti = new SqlCommand();
                cmdHesapOzeti.Connection = con;
                cmdHesapOzeti.CommandText = "select cart.* from LG_CSTVND musteri inner join [dbo].[LG_CVARPASG] iliski on musteri.LOGICALREF=iliski.CSTVNDREF inner join LG_" + IzoKaleFirmaNo + "_CLCARD cart on iliski.ARPREF=cart.LOGICALREF where musteri.CODE='" + BayiKodu + "' and iliski.FIRMNO=" + IzoKaleFirmaNo;
                SqlDataReader rdHesapOzeti = cmdHesapOzeti.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdHesapOzeti);
                con.Close();
                return JsonConvert.SerializeObject(dt);
            }

        }

        [WebMethod]
        public string WCFOdemePlanlari()
        {
            List<WCFOdemePlani> odemePlanlari = new List<WCFOdemePlani>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =

                    "    SELECT LOGICALREF OdemePlaniId, CODE OdemePlaniKodu, DEFINITION_  AS OdemePlaniAciklamasi "
                    + "        FROM LG_" + IzoKaleFirmaNo + "_PAYPLANS WITH(NOLOCK) WHERE ACTIVE = 0 AND SPECODE='001' ORDER BY CODE ASC ";

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    WCFOdemePlani odemePlani = new WCFOdemePlani();
                    odemePlani.OdemePlaniId = rd["OdemePlaniId"].ToString();
                    odemePlani.OdemePlaniKodu = rd["OdemePlaniKodu"].ToString();
                    odemePlani.OdemePlaniAciklamasi = rd["OdemePlaniAciklamasi"].ToString();
                    odemePlanlari.Add(odemePlani);
                }

                con.Close();
            }
            return JsonConvert.SerializeObject(odemePlanlari, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }
        [WebMethod]
        public string WCFSatisElemanlari()
        {
            List<WCFSatisElemani> satisElemanlari = new List<WCFSatisElemani>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =

                    "    SELECT CODE SatisElemaniKodu, DEFINITION_  AS SatisElemaniAciklamasi "
                    + "        FROM LG_SLSMAN WITH(NOLOCK) WHERE ACTIVE = 0 AND (FIRMNR = " + IzoKaleFirmaNo + " OR FIRMNR = -1) ORDER BY DEFINITION_ ASC";

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    WCFSatisElemani satisElemani = new WCFSatisElemani();
                    satisElemani.SatisElemaniKodu = rd["SatisElemaniKodu"].ToString();
                    satisElemani.SatisElemaniAciklamasi = rd["SatisElemaniAciklamasi"].ToString();
                    satisElemanlari.Add(satisElemani);
                }

                con.Close();
            }

            return JsonConvert.SerializeObject(satisElemanlari, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });

        }


        [WebMethod]
        public string IsyeriBilgileri()
        {
            List<WCFIsYeri> IsyeriBilgileri = new List<WCFIsYeri>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select NR as IsYeriKodu,NAME IsYeriAdi from L_CAPIDIV where FIRMNR=" + IzoKaleFirmaNo;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int isYeriNo = Convert.ToInt32(rd["IsYeriKodu"].ToString());
                    WCFIsYeri IsyeriBilgisi = new WCFIsYeri();
                    IsyeriBilgisi.IsYeriAciklamasi = rd["IsYeriAdi"].ToString();
                    IsyeriBilgisi.IsYeriKodu = (isYeriNo >= 100) ? isYeriNo.ToString() : (isYeriNo >= 10) ? "0" + isYeriNo : "00" + isYeriNo;
                    IsyeriBilgileri.Add(IsyeriBilgisi);
                }

                con.Close();
            }
            return JsonConvert.SerializeObject(IsyeriBilgileri, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });
        }


        [WebMethod]
        public string FabrikaBilgileri()
        {
            List<WCFFabrika> FabrikaBilgileri = new List<WCFFabrika>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select NR as FabrikaKodu,NAME FabrikaAdi from L_CAPIFACTORY where FIRMNR=" + IzoKaleFirmaNo;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int FabrikaNo = Convert.ToInt32(rd["FabrikaKodu"].ToString());
                    WCFFabrika FabrikaBilgisi = new WCFFabrika();
                    FabrikaBilgisi.FabrikaAciklamasi = rd["FabrikaAdi"].ToString();
                    FabrikaBilgisi.FabrikaKodu = (FabrikaNo >= 100) ? FabrikaNo.ToString() : (FabrikaNo >= 10) ? "0" + FabrikaNo : "00" + FabrikaNo;
                    FabrikaBilgileri.Add(FabrikaBilgisi);
                }

                con.Close();
            }
            return JsonConvert.SerializeObject(FabrikaBilgileri, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });
        }

        [WebMethod]
        public string BolumBilgileri()
        {
            List<WCFBolum> BolumBilgileri = new List<WCFBolum>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select NR as BolumKodu,NAME BolumAdi from L_CAPIDEPT where FIRMNR=" + IzoKaleFirmaNo;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int BolumNo = Convert.ToInt32(rd["BolumKodu"].ToString());
                    WCFBolum BolumBilgisi = new WCFBolum();
                    BolumBilgisi.BolumAciklamasi = rd["BolumAdi"].ToString();
                    BolumBilgisi.BolumKodu = (BolumNo >= 100) ? BolumNo.ToString() : (BolumNo >= 10) ? "0" + BolumNo : "00" + BolumNo;
                    BolumBilgileri.Add(BolumBilgisi);
                }

                con.Close();
            }
            return JsonConvert.SerializeObject(BolumBilgileri, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });
        }


        [WebMethod]
        public string AmbarBilgileri()
        {
            List<WCFAmbar> AmbarBilgileri = new List<WCFAmbar>();
            using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select NR as AmbarKodu,NAME AmbarAdi from L_CAPIWHOUSE where FIRMNR=" + IzoKaleFirmaNo;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int AmbarNo = Convert.ToInt32(rd["AmbarKodu"].ToString());
                    WCFAmbar AmbarBilgisi = new WCFAmbar();
                    AmbarBilgisi.AmbarAciklamasi = rd["AmbarAdi"].ToString();
                    AmbarBilgisi.AmbarKodu = (AmbarNo >= 100) ? AmbarNo.ToString() : (AmbarNo >= 10) ? "0" + AmbarNo : "00" + AmbarNo;
                    AmbarBilgileri.Add(AmbarBilgisi);
                }

                con.Close();
            }
            return JsonConvert.SerializeObject(AmbarBilgileri, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });
        }


        [WebMethod]
        public string WCFSozlesmeBilgileri(string BayiKodu, int BaglantiLREF)
        {
            WCFSozlesmeBilgileri sozlesme = new WCFSozlesmeBilgileri();
            if (BaglantiLREF == -1)
            {
                sozlesme.SozlesmeFisNo = "";
            }
            else
            {

                sozlesme.SozlesmeLREF = -1;
                using (SqlConnection con = new SqlConnection(IzoKaleConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText =


                     "                  SELECT "
                   + "\n                  SOZLESME.FICHENO AS SozlesmeFisNo, "
                   + "\n                  ISNULL(MUSTERI.CODE, '-') AS MusteriKodu, "
                   + "\n                  ISNULL(MUSTERI.TITLE, '!! MÜŞTERİYE BAĞLANMAMIŞ !!') AS MusteriAdi,  "
                   + "\n                  ISNULL(SOZLESME.DOCODE, ' - ') AS FiyatListesi, "
                   + "\n                  ISNULL(SOZLESME.LOGICALREF, -1) AS BaglantiLREF "

                   + "\n                  FROM "
                   + "\n                    LG_" + IzoKaleFirmaNo + "_PURCHOFFER SOZLESME  "
                   + "\n                     LEFT JOIN LG_" + IzoKaleFirmaNo + "_CLCARD CARI ON SOZLESME.CLIENTREF = CARI.LOGICALREF "
                   + "\n                      LEFT JOIN LG_CVARPASG ILISKI ON ILISKI.ARPREF = CARI.LOGICALREF AND FIRMNO = " + IzoKaleFirmaNo + " "
                   + "\n                       LEFT JOIN LG_CSTVND MUSTERI ON ILISKI.CSTVNDREF = MUSTERI.LOGICALREF AND MUSTERI.CARDTYPE = 1 "
                   + "\n                  WHERE SOZLESME.TRCODE = 1 AND SOZLESME.TYP = 2 AND SOZLESME.CANCELLED = 0 AND MUSTERI.CODE = '" + BayiKodu + "' AND SOZLESME.LOGICALREF = " + BaglantiLREF;


                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {

                        sozlesme.SozlesmeAdi = rd["FiyatListesi"].ToString();
                        sozlesme.SozlesmeFisNo = rd["SozlesmeFisNo"].ToString();
                        sozlesme.SozlesmeLREF = Convert.ToInt32(rd["BaglantiLREF"].ToString());
                    }

                    con.Close();
                }

            }

            return JsonConvert.SerializeObject(sozlesme, new IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" });
        }

        public bool M2BMukerrerKayitKontrol(string MusteriSiparisNo)
        {
            bool resultsonuc = false;
            using (SqlConnection sqlcon = new SqlConnection(IzoKaleConnectionString))
            {
                using (SqlCommand _sqlcomm = new SqlCommand())
                {
                    _sqlcomm.Connection = sqlcon;
                    sqlcon.Open();
                    _sqlcomm.CommandText = " select * from LG_" + IzoKaleFirmaNo + "_" + IzoKaleDonemNo + "_ORFICHE WHERE CUSTORDNO='" + MusteriSiparisNo + "'";
                    SqlDataReader dr;
                    dr = _sqlcomm.ExecuteReader();
                    while (dr.Read())
                    {
                        resultsonuc = true;
                    }
                }
            }
            return resultsonuc;
        }
        public string PlakaKoduBul(string il)
        {
            string PlakaKodu = null;
            il = il.ToUpper();
            switch (il)
            {
                case "ADANA":
                    PlakaKodu = "01";
                    break;

                case "ADIYAMAN":
                    PlakaKodu = "02";
                    break;

                case "AFYONKARAHİSAR":
                    PlakaKodu = "03";
                    break;

                case "AĞRI":
                    PlakaKodu = "04";
                    break;

                case "AMASYA":
                    PlakaKodu = "05";
                    break;

                case "ANKARA":
                    PlakaKodu = "06";
                    break;

                case "ANTALYA":
                    PlakaKodu = "07";
                    break;

                case "ARTVİN":
                    PlakaKodu = "08";
                    break;

                case "AYDIN":
                    PlakaKodu = "09";
                    break;

                case "BALIKESİR":
                    PlakaKodu = "10";
                    break;

                case "BİLECİK":
                    PlakaKodu = "11";
                    break;

                case "BİNGÖL":
                    PlakaKodu = "12";
                    break;

                case "BİTLİS":
                    PlakaKodu = "13";
                    break;

                case "BOLU":
                    PlakaKodu = "14";
                    break;

                case "BURDUR":
                    PlakaKodu = "15";
                    break;

                case "BURSA":
                    PlakaKodu = "16";
                    break;

                case "ÇANAKKALE":
                    PlakaKodu = "17";
                    break;

                case "ÇANKIRI":
                    PlakaKodu = "18";
                    break;

                case "ÇORUM":
                    PlakaKodu = "19";
                    break;

                case "DENİZLİ":
                    PlakaKodu = "20";
                    break;

                case "DİYARBAKIR":
                    PlakaKodu = "21";
                    break;

                case "EDİRNE":
                    PlakaKodu = "22";
                    break;

                case "ELAZIĞ":
                    PlakaKodu = "23";
                    break;

                case "ERZİNCAN":
                    PlakaKodu = "24";
                    break;

                case "ERZURUM":
                    PlakaKodu = "25";
                    break;

                case "ESKİŞEHİR":
                    PlakaKodu = "26";
                    break;

                case "GAZİANTEP":
                    PlakaKodu = "27";
                    break;

                case "GİRESUN":
                    PlakaKodu = "28";
                    break;

                case "GÜMÜŞHANE":
                    PlakaKodu = "29";
                    break;

                case "HAKKARİ":
                    PlakaKodu = "30";
                    break;

                case "HATAY":
                    PlakaKodu = "31";
                    break;

                case "ISPARTA":
                    PlakaKodu = "32";
                    break;

                case "MERSİN":
                    PlakaKodu = "33";
                    break;

                case "İSTANBUL":
                    PlakaKodu = "34";
                    break;
                case "İSTANBUL AVRUPA":
                    PlakaKodu = "34";
                    break;
                case "İSTANBUL ANADOLU":
                    PlakaKodu = "34";
                    break;

                case "İZMİR":
                    PlakaKodu = "35";
                    break;

                case "KARS":
                    PlakaKodu = "36";
                    break;

                case "KASTAMONU":
                    PlakaKodu = "37";
                    break;

                case "KAYSERİ":
                    PlakaKodu = "38";
                    break;

                case "KIRKLARELİ":
                    PlakaKodu = "39";
                    break;

                case "KIRŞEHİR":
                    PlakaKodu = "40";
                    break;

                case "KOCAELİ":
                    PlakaKodu = "41";
                    break;

                case "İZMİT":
                    PlakaKodu = "41";
                    break;

                case "KONYA":
                    PlakaKodu = "42";
                    break;

                case "KÜTAHYA":
                    PlakaKodu = "43";
                    break;

                case "MALATYA":
                    PlakaKodu = "44";
                    break;

                case "MANİSA":
                    PlakaKodu = "45";
                    break;

                case "KAHRAMANMARAŞ":
                    PlakaKodu = "46";
                    break;

                case "MARAŞ":
                    PlakaKodu = "46";
                    break;

                case "MARDİN":
                    PlakaKodu = "47";
                    break;

                case "MUĞLA":
                    PlakaKodu = "48";
                    break;

                case "MUŞ":
                    PlakaKodu = "49";
                    break;

                case "NEVŞEHİR":
                    PlakaKodu = "50";
                    break;

                case "NİĞDE":
                    PlakaKodu = "51";
                    break;

                case "ORDU":
                    PlakaKodu = "52";
                    break;

                case "RİZE":
                    PlakaKodu = "53";
                    break;

                case "SAKARYA":
                    PlakaKodu = "54";
                    break;

                case "ADAPAZARI":
                    PlakaKodu = "54";
                    break;

                case "SAMSUN":
                    PlakaKodu = "55";
                    break;

                case "SİİRT":
                    PlakaKodu = "56";
                    break;

                case "SİNOP":
                    PlakaKodu = "57";
                    break;

                case "SİVAS":
                    PlakaKodu = "58";
                    break;

                case "TEKİRDAĞ":
                    PlakaKodu = "59";
                    break;

                case "TOKAT":
                    PlakaKodu = "60";
                    break;

                case "TRABZON":
                    PlakaKodu = "61";
                    break;

                case "TUNCELİ":
                    PlakaKodu = "62";
                    break;

                case "ŞANLIURFA":
                    PlakaKodu = "63";
                    break;

                case "UŞAK":
                    PlakaKodu = "64";
                    break;

                case "VAN":
                    PlakaKodu = "65";
                    break;

                case "YOZGAT":
                    PlakaKodu = "66";
                    break;

                case "ZONGULDAK":
                    PlakaKodu = "67";
                    break;

                case "AKSARAY":
                    PlakaKodu = "68";
                    break;

                case "BAYBURT":
                    PlakaKodu = "69";
                    break;

                case "KARAMAN":
                    PlakaKodu = "70";
                    break;

                case "KIRIKKALE":
                    PlakaKodu = "71";
                    break;

                case "BATMAN":
                    PlakaKodu = "72";
                    break;

                case "ŞIRNAK":
                    PlakaKodu = "73";
                    break;

                case "BARTIN":
                    PlakaKodu = "74";
                    break;

                case "ARDAHAN":
                    PlakaKodu = "75";
                    break;

                case "IĞDIR":
                    PlakaKodu = "76";
                    break;

                case "YALOVA":
                    PlakaKodu = "77";
                    break;

                case "KARABÜK":
                    PlakaKodu = "78";
                    break;

                case "KİLİS":
                    PlakaKodu = "79";
                    break;

                case "OSMANİYE":
                    PlakaKodu = "80";
                    break;

                case "DÜZCE":
                    PlakaKodu = "81";
                    break;
            }

            return PlakaKodu;
        }
        public string Ilcekodugetir(string _ilce, string _il)
        {
            string ilcekodu = "";
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(IzoKaleConnectionString))
                {
                    using (SqlCommand _sqlcomm = new SqlCommand())
                    {
                        _sqlcomm.Connection = sqlcon;
                        sqlcon.Open();
                        _sqlcomm.CommandText = "SELECT TOP 1 CODE FROM L_TOWN WHERE NAME='" + _ilce + "' AND CTYREF =(SELECT CODE FROM L_CITY WHERE CODE='" + _il + "')";
                        try
                        {
                            ilcekodu = _sqlcomm.ExecuteScalar().ToString();
                        }
                        catch (Exception ex)
                        {
                            ilcekodu = null;
                        }
                        sqlcon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ilcekodu = null;
            }

            return ilcekodu;
        }
        public string YeniSevkiyatKoduOlustur()
        {
            string resultsevkiyatkodu = "";
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(IzoKaleConnectionString))
                {
                    using (SqlCommand _sqlcomm = new SqlCommand())
                    {
                        _sqlcomm.Connection = sqlcon;
                        sqlcon.Open();
                        _sqlcomm.CommandText = "select max(CONVERT(int,REPLACE(CODE,'.','')))+1 as num_ from LG_" + IzoKaleFirmaNo + "_SHIPINFO WHERE ISNumeric(CODE)=1";
                        try
                        {
                            resultsevkiyatkodu = _sqlcomm.ExecuteScalar().ToString();
                        }
                        catch (Exception ex)
                        {
                            resultsevkiyatkodu = null;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                resultsevkiyatkodu = "YeniSevkiyatKoduOlustur kısmında hata!\n" + ex.ToString();
            }
            return resultsevkiyatkodu;



        }

        public void dosyayaYaz(string xml)
        {
            string dosya_yolu = HttpContext.Current.Server.MapPath("~") + "/order_xml_log.xml";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(xml);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
       /* [WebMethod]
        public String M2BSiparisOlustur(string Ambar, M2BWCFBaslik Baslik, List<M2BWCFTransaction> Transactions, CariSevkAdresi AdresBilgileri)
        {
            return "";
        }*/



        static UnityObjects.UnityApplication obj = new UnityObjects.UnityApplication();
        [WebMethod]
        public string test()
        {

            obj.Login("LOGOFLOW", "1234", Convert.ToInt32(IzoKaleFirmaNo));
            if (obj.LoggedIn)
            {
                obj.Disconnect();
                return "bağlantı başarılı";
            }
            else
            {
                return obj.GetLastError() + "/" + obj.GetLastErrorString();
            }

        }
        public string CariSevkAdresiKoduGetir(string CariKod, CariSevkAdresi _gelenAdresBilgileri, string YetkiKodu, string Ulke, string UlkeKodu)
        {
            string resultCariSevkKodu = "";
            YetkiKodu = "1";



            try
            {
                using (SqlConnection sqlcon = new SqlConnection(IzoKaleConnectionString))
                {
                    using (SqlCommand sqlcmd = new SqlCommand())
                    {
                        sqlcmd.CommandText = "SELECT TOP 1 * FROM LG_" + IzoKaleFirmaNo + @"_SHIPINFO WHERE 
                                                    CLIENTREF=(SELECT LOGICALREF FROM LG_" + IzoKaleFirmaNo + "_CLCARD WHERE CODE='" + CariKod + @"' AND ACTIVE=0) 
                                                    AND NAME='" + _gelenAdresBilgileri.AdresBasligi + @"'
                                                    AND ADDR1='" + _gelenAdresBilgileri.Adres1 + @"' 
                                                    AND ADDR2='" + _gelenAdresBilgileri.Adres2 + @"'
                                                    AND UPPER(CITY)=UPPER('" + _gelenAdresBilgileri.Il + @"')
                                                AND UPPER(TOWN)=UPPER('" + _gelenAdresBilgileri.Ilce + @"') AND ACTIVE=0";
                        SqlDataReader dr;
                        sqlcmd.Connection = sqlcon;
                        sqlcon.Open();
                        dr = sqlcmd.ExecuteReader();
                        bool varmi = false;
                        while (dr.Read())
                        {
                            varmi = true;
                            //if (_gelenAdresBilgileri.Adres1 == dr["ADDR1"].ToString() && _gelenAdresBilgileri.Adres2 == dr["ADDR2"].ToString() && _gelenAdresBilgileri.Il.ToUpper() == dr["CITY"].ToString().ToUpper() && _gelenAdresBilgileri.Ilce.ToUpper() == dr["TOWN"].ToString().ToUpper())
                            //{
                            resultCariSevkKodu = "OK " + dr["Code"].ToString();
                            //}
                            //else
                            //{
                            //Update sorgusunu yaz sana zahmet
                            //}
                        }
                        if (!varmi)
                        {



                            //İl Plaka Kodunu Bul
                            string ilPlakakodu = PlakaKoduBul(_gelenAdresBilgileri.Il.ToUpper());
                            if (ilPlakakodu == null)
                            {
                                // obj.Disconnect();
                                return "İl/Şehir Bilgisinin Logo'da Karşılığı yok :" + _gelenAdresBilgileri.Il;
                            }
                            string ilcekodu = Ilcekodugetir(_gelenAdresBilgileri.Ilce.ToUpper(), ilPlakakodu);
                            if (ilcekodu == null)
                            {
                                //  obj.Disconnect();
                                if (_gelenAdresBilgileri.Ilce.ToUpper() != "MERKEZ")
                                {
                                    return "İlçe Bilgisinin Logo'da Karşılığı yok :" + _gelenAdresBilgileri.Ilce;
                                }

                            }
                            //sevk kodu oluştur
                            string sevkkodu = YeniSevkiyatKoduOlustur();
                            if (sevkkodu == null)
                            {
                                //  obj.Disconnect();
                                return "Uygun Sevkiyat Kodu Oluşturulamadı!";
                            }
                            //--------------------
                            //********************************
                            obj.Login("LOGOFLOW", "1234", Convert.ToInt32(IzoKaleFirmaNo));

                            var item = obj.NewDataObject(UnityObjects.DataObjectType.doArpShipLic);
                            item.New();
                            item.DataFields.FieldByName("ARP_CODE").Value = CariKod;
                            item.DataFields.FieldByName("CODE").Value = sevkkodu;
                            item.DataFields.FieldByName("DESCRIPTION").Value = _gelenAdresBilgileri.AdresBasligi;
                            item.DataFields.FieldByName("TITLE").Value = _gelenAdresBilgileri.Aciklama1;
                            item.DataFields.FieldByName("AUTH_CODE").Value = YetkiKodu;
                            item.DataFields.FieldByName("ADDRESS1").Value = _gelenAdresBilgileri.Adres1;
                            item.DataFields.FieldByName("ADDRESS2").Value = _gelenAdresBilgileri.Adres2;
                            item.DataFields.FieldByName("TOWN_CODE").Value = ilcekodu;
                            item.DataFields.FieldByName("TOWN").Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_gelenAdresBilgileri.Ilce.ToLower());
                            item.DataFields.FieldByName("CITY_CODE").Value = ilPlakakodu;
                            item.DataFields.FieldByName("CITY").Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_gelenAdresBilgileri.Il.ToLower());
                            item.DataFields.FieldByName("COUNTRY_CODE").Value = UlkeKodu;
                            item.DataFields.FieldByName("COUNTRY").Value = Ulke;
                            item.DataFields.FieldByName("POSTAL_CODE").Value = ilPlakakodu;
                            item.DataFields.FieldByName("SHIP_BEG_TIME1").Value = "134217728";
                            item.DataFields.FieldByName("SHIP_END_TIME1").Value = "288817152";
                            if (item.Post())
                            {

                                resultCariSevkKodu = "OK " + sevkkodu;

                            }
                            else
                            {
                                if (item.ErrorCode != 0)
                                {
                                    resultCariSevkKodu = "DB Error : (" + item.ErrorCode.ToString() + ") - " + item.DBErrorDesc + " " + sevkkodu;
                                }
                                else if (item.ValidateErrors.Count > 0)
                                {
                                    for (int i = 0; i < item.ValidateErrors.Count - 1; i++)
                                    {
                                        resultCariSevkKodu += ("XML Error : (" + item.ValidateErrors[i].ID.ToString() + ") - " + item.ValidateErrors[i].Error) + " \n";
                                    }
                                }
                            }
                            obj.Disconnect();
                            //***********************************
        #region
                            //WCFService.SvcClient LoClient = new WCFService.SvcClient();
                            //LoClient.Open();
                            //int DataType = 34;
                            //int DataRef = 0;
                            //string DataXml = "";
                            //string ParamXml = "";
                            //string ErrorStr = "";
                            //byte Status = 32;

                            //DataXml = "  <?xml version=\"1.0\" encoding=\"ISO-8859-9\"?>                                                                        "
                            //        + "     <ARP_SHIPMENT_LOCATIONS>                                                                                            "
                            //        + "             <SHIPMENT_LOC DBOP = \"INS\">                                                                               "
                            //        + "             <ARP_CODE >" + CariKod + "</ARP_CODE>                                                                       "
                            //        + "             <CODE>" + sevkkodu + "</CODE>                                                                               "
                            //        + "             <DESCRIPTION>" + _gelenAdresBilgileri.AdresBasligi + "</DESCRIPTION>                                        "
                            //        + "             <TITLE>" + _gelenAdresBilgileri.Aciklama1 + "</TITLE>                                                       "
                            //        + "             <AUTH_CODE>" + YetkiKodu + "</AUTH_CODE>                                                                    "
                            //        + "             <ADDRESS1>" + _gelenAdresBilgileri.Adres1 + "</ADDRESS1>                                                    "
                            //        + "             <ADDRESS2>" + _gelenAdresBilgileri.Adres2 + "</ADDRESS2>                                                    "
                            //        + "             <TOWN_CODE>" + ilcekodu + "</TOWN_CODE>                                                                     "
                            //        + "             <TOWN>" + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_gelenAdresBilgileri.Ilce.ToLower()) + "</TOWN>   "
                            //        + "             <CITY_CODE>" + ilPlakakodu + "</CITY_CODE>                                                                  "
                            //        + "             <CITY>" + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_gelenAdresBilgileri.Il.ToLower()) + "</CITY>     "
                            //        + "             <COUNTRY_CODE>" + UlkeKodu + "</COUNTRY_CODE>                                                               "
                            //        + "             <COUNTRY>" + Ulke + "</COUNTRY>                                                                             "
                            //        + "             <POSTAL_CODE>" + ilPlakakodu + "000</POSTAL_CODE>                                                                  "
                            //        + "             <SHIP_BEG_TIME1>134217728</SHIP_BEG_TIME1>                                                                  "
                            //        + "             <SHIP_END_TIME1>288817152</SHIP_END_TIME1>                                                                  "
                            //        + "             </SHIPMENT_LOC>                                                                                             "
                            //        + "     </ARP_SHIPMENT_LOCATIONS>                                                                                           ";

                            //ParamXml = "<?xml version=\"1.0\" encoding=\"utf-16\"?>"
                            //               + "<Parameters>"
                            //               + "  <ReplicMode>0</ReplicMode>"
                            //               + "  <CheckParams>0</CheckParams>" // 0 olsa ambar parametrelerini kontrol et / 1 pasif
                            //               + "  <CheckRight>0</CheckRight>" // 0 olsa yetkiler aktif / 1 pasif
                            //               + "  <ApplyCampaign>0</ApplyCampaign>" // kampanya
                            //               + "  <ApplyCondition>0</ApplyCondition>" // satış koşulu
                            //               + "  <FillAccCodes>0</FillAccCodes>" // muhasebe kodlarını doldur
                            //               + "  <FormSeriLotLines>0</FormSeriLotLines>" // 
                            //               + "  <GetStockLinePrice>0</GetStockLinePrice>" // son satırın istenilen fiyat bilgisini otomatik set etmek için kullanılır
                            //               + "  <ExportAllData>0</ExportAllData>" // 
                            //               + "  <Validation>1</Validation>" // 1: logoobject doğrulama yapar, 0 doğrulama yapmaz
                            //               + "</Parameters>";
                            //LoClient.AppendDataObject(DataType, ref DataRef, ref DataXml, ref ParamXml, ref ErrorStr, ref Status, LbsLoadSecurityCode, Convert.ToInt32(IzoKaleFirmaNo), SecurityCode);
                            //if (Status == 4)
                            //{
                            //    resultCariSevkKodu = ErrorStr + "\r" + DataXml;
                            //}
                            //else
                            //{
                            //    resultCariSevkKodu = "OK " + sevkkodu;
                            //}
        #endregion
                        }
                        sqlcon.Close();
                        sqlcon.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                if (obj.LoggedIn)
                {
                    obj.Disconnect();
                    return "Objeye Bağlanılamadı";
                }
                resultCariSevkKodu = "CariSevkAdresiKoduGetir kısmında hata!\n" + ex.ToString();
            }

            return resultCariSevkKodu;

        }

        [WebMethod]
        public String M2BSiparisOlustur(string Ambar, M2BWCFBaslik Baslik, List<M2BWCFTransaction> Transactions, CariSevkAdresi AdresBilgileri)
        {
            string retMesaj = "";


            try
            {



                int DataType = 3;
                int DataRef = 0;
                string DataXml = "";
                string ParamXml = "";
                string ErrorStr = "";
                byte Status = 32;


                int FirmNr = Convert.ToInt32(IzoKaleFirmaNo);
                //Mükerrek Kayıt varmı yokmu
                if (M2BMukerrerKayitKontrol(Baslik.MusteriSiparisNo))
                {
                    return "Bu Sipariş Daha Önceden Aktarılmış!";
                }
                //--------------------------
                SqlConnection con = new SqlConnection(IzoKaleConnectionString);

                SqlCommand cmd = new SqlCommand();

                string CariHesapUnvani = "";
                string AcceptEInv = "0";
                string ProfileId = "0";
                cmd.CommandText = "SELECT TOP 1 CODE,DEFINITION_, ACCEPTEINV,PROFILEID FROM LG_" + FirmNr + "_CLCARD WHERE LOGICALREF =  '" + Baslik.CariLREF + "'";
                cmd.Connection = con;
                con.Open();
                string CariKod = "";
                SqlDataReader rd2 = cmd.ExecuteReader();
                if (rd2.Read())
                {
                    CariHesapUnvani = rd2["DEFINITION_"].ToString();
                    AcceptEInv = rd2["ACCEPTEINV"].ToString();
                    ProfileId = rd2["PROFILEID"].ToString();
                    CariKod = rd2["CODE"].ToString(); ;
                }
                rd2.Close();
                con.Close();

                string SevkAdresiKodu = CariSevkAdresiKoduGetir(CariKod, AdresBilgileri, Baslik.YetkiKodu, "TÜRKİYE", "TR");
                if (SevkAdresiKodu.Substring(0, 2) == "OK")
                {
                    SevkAdresiKodu = SevkAdresiKodu.Substring(3, SevkAdresiKodu.Length - 3);
                }
                else
                {
                    return SevkAdresiKodu;
                }






                var guncelTarih = DateTime.Now;
                int guncelSaat = guncelTarih.Hour;
                int guncelDk = guncelTarih.Minute;
                int guncelSn = guncelTarih.Second;
                int UzunTime = (guncelSaat * 65536 * 256) + (guncelDk * 65536) + (guncelSn * 256);

                obj.Login("LOGOFLOW", "1234", Convert.ToInt32(IzoKaleFirmaNo));
                var item = obj.NewDataObject(UnityObjects.DataObjectType.doSalesOrderSlip);
                item.New();
                item.DataFields.FieldByName("NUMBER").Value = "~";
                item.DataFields.FieldByName("WITH_PAYMENT").Value = "0";
                item.DataFields.FieldByName("DOC_TRACK_NR").Value = Baslik.DokumanIzlemeNumarasi;
                item.DataFields.FieldByName("DATE").Value = Baslik.Tarih;
                item.DataFields.FieldByName("TIME").Value = UzunTime;
                item.DataFields.FieldByName("AUTH_CODE").Value = Baslik.YetkiKodu;
                item.DataFields.FieldByName("ARP_CODE").Value = CariKod;
                item.DataFields.FieldByName("SHIPLOC_CODE").Value = SevkAdresiKodu;
                item.DataFields.FieldByName("NOTES1").Value = Baslik.Aciklama1;
                item.DataFields.FieldByName("NOTES2").Value = Baslik.Aciklama2;
                item.DataFields.FieldByName("NOTES3").Value = Baslik.Aciklama3;
                item.DataFields.FieldByName("NOTES4").Value = Baslik.Aciklama4;
                item.DataFields.FieldByName("ITEXT").Value = Baslik.AdresBasligi;
                item.DataFields.FieldByName("ORDER_STATUS").Value = "1";
                item.DataFields.FieldByName("AUXIL_CODE").Value = Baslik.OzelKod;
                item.DataFields.FieldByName("PAYMENT_CODE").Value = Baslik.OdemeTipiKodu;
                item.DataFields.FieldByName("SALESMAN_CODE").Value = Baslik.SatisElemaniKodu;
                item.DataFields.FieldByName("PROJECT_CODE").Value = Baslik.ProjeKodu;
                item.DataFields.FieldByName("SHIPMENT_TYPE").Value = Baslik.TeslimSekliKodu;
                item.DataFields.FieldByName("TRADING_GRP").Value = Baslik.TicariIslemGrubu;
                item.DataFields.FieldByName("CUST_ORD_NO").Value = Baslik.MusteriSiparisNo;
                item.DataFields.FieldByName("OFFER_REFERENCE").Value = Baslik.SozlesmeReferansi;
                item.DataFields.FieldByName("DIVISION").Value = Baslik.Bolum;
                item.DataFields.FieldByName("DEPARTMENT").Value = Baslik.Isyeri;
                item.DataFields.FieldByName("FACTORY").Value = Baslik.Fabrika;
                item.DataFields.FieldByName("SOURCE_WH").Value = Baslik.Ambar;
                //if (AcceptEInv == "1")
                //{
                //    item.DataFields.FieldByName("EINVOICE").Value = "1";
                //    item.DataFields.FieldByName("EINVOICE_PROFILEID").Value = ProfileId;

                //}
                //else
                //{
                //    item.DataFields.FieldByName("EINVOICE").Value = "2";
                //    item.DataFields.FieldByName("EARCHIVEDETR_SENDMOD").Value = "2";
                //    item.DataFields.FieldByName("EARCHIVEDETR_INTPAYMENTTYPE").Value = "4";
                //}
                DataXml = "  <?xml version=\"1.0\" encoding=\"ISO-8859-9\"?>  "
                          + "\n         <SALES_ORDERS> "
                          + "\n           <ORDER_SLIP DBOP=\"INS\">"
                          + "\n             <NUMBER>~</NUMBER> "
                          + "\n             <WITH_PAYMENT>0</WITH_PAYMENT> "
                          + "\n             <DOC_TRACK_NR>" + Baslik.DokumanIzlemeNumarasi + "</DOC_TRACK_NR>"
                          + "\n             <DATE>" + Baslik.Tarih + "</DATE>"
                          + "\n             <TIME>" + UzunTime + "</TIME>"
                          + "\n             <AUTH_CODE>" + Baslik.YetkiKodu + "</AUTH_CODE>"
                          + "\n             <ARP_CODE>" + CariKod + "</ARP_CODE> "
                          + "\n             <SHIPLOC_CODE>" + SevkAdresiKodu + "</SHIPLOC_CODE> "
                          + "\n             <NOTES1>" + Baslik.Aciklama1 + "</NOTES1> "
                          + "\n             <NOTES2>" + Baslik.Aciklama2 + "</NOTES2> "
                          + "\n             <NOTES3>" + Baslik.Aciklama3 + "</NOTES3> "
                          + "\n             <NOTES4>" + Baslik.Aciklama4 + "</NOTES4> "
                          + "\n             <ITEXT>" + Baslik.AdresBasligi + "</ITEXT> "
                          + "\n             <ORDER_STATUS>1</ORDER_STATUS> "
                          + "\n              <AUXIL_CODE>" + Baslik.OzelKod + "</AUXIL_CODE>"
                          + "\n              <PAYMENT_CODE>" + Baslik.OdemeTipiKodu + "</PAYMENT_CODE> "
                          + "\n              <SALESMAN_CODE>" + Baslik.SatisElemaniKodu + "</SALESMAN_CODE> "
                          + "\n              <PROJECT_CODE>" + Baslik.ProjeKodu + "</PROJECT_CODE> "
                          + "\n              <SHIPMENT_TYPE>" + Baslik.TeslimSekliKodu + "</SHIPMENT_TYPE> "
                          + "\n              <TRADING_GRP>" + Baslik.TicariIslemGrubu + "</TRADING_GRP> "
                          + "\n              <CUST_ORD_NO>" + Baslik.MusteriSiparisNo + "</CUST_ORD_NO> "
                          + "\n              <OFFER_REFERENCE>" + Baslik.SozlesmeReferansi + "</OFFER_REFERENCE> "
                          + "\n              <DIVISION>" + Baslik.Bolum + "</DIVISION>"
                          + "\n              <DEPARTMENT>" + Baslik.Isyeri + "</DEPARTMENT>"
                          + "\n              <FACTORY>" + Baslik.Fabrika + "</FACTORY>"
                          + "\n              <SOURCE_WH>" + Baslik.Ambar + "</SOURCE_WH>";



                //if (AcceptEInv == "1")
                //{
                //    DataXml = DataXml
                //          + "\n             <EINVOICE>1</EINVOICE> <EINVOICE_PROFILEID>" + ProfileId + "</EINVOICE_PROFILEID>";
                //}
                //else
                //{
                //    DataXml = DataXml
                //        + "\n             <EINVOICE>2</EINVOICE> ";
                //}





                DataXml = DataXml + "\n            <TRANSACTIONS>";
                var transactionstransaction = item.DataFields.FieldByName("TRANSACTIONS").Lines;
                foreach (M2BWCFTransaction Transaction in Transactions)
                {
                    transactionstransaction.AppendLine();
                    if (Transaction.SatirTipi == 0)
                    {
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("TYPE").Value = Transaction.SatirTipi;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("MASTER_CODE").Value = Transaction.MalzemeKodu;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("AUXIL_CODE").Value = Transaction.HareketOzelKodu.Replace('.', ',');
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("QUANTITY").Value = Transaction.Miktar.ToString().Replace(',', '.');
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("PRICE").Value = Transaction.BirimFiyat.ToString().Replace(',', '.');
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("TOTAL").Value = Transaction.Toplam.ToString().Replace(',', '.');
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("VAT_RATE").Value = Transaction.Kdv.ToString().Replace(',', '.');
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("VAT_INCLUDED").Value = Transaction.KdvHaricmi0;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("TRANS_DESCRIPTION").Value = Transaction.SatirAciklamasi;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("DUE_DATE").Value = Baslik.Tarih;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("UNIT_CODE").Value = Transaction.Birim;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("UNIT_CONV1").Value = "1";
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("UNIT_CONV2").Value = "2";
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("SALESMAN_CODE").Value = Baslik.SatisElemaniKodu;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("MULTI_ADD_TAX").Value = "0";
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("EDT_CURR").Value = "1";
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("SOURCE_WH").Value = Ambar;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("DETAILS").Value = "1";

                        DataXml = DataXml
                          + "\n              <TRANSACTION>"
                          + "\n                <TYPE>" + Transaction.SatirTipi + "</TYPE> "
                          + "\n                <MASTER_CODE>" + Transaction.MalzemeKodu + "</MASTER_CODE>"
                          + "\n                <AUXIL_CODE>" + Transaction.HareketOzelKodu.Replace('.', ',') + "</AUXIL_CODE>"
                          + "\n                <QUANTITY>" + Transaction.Miktar.ToString().Replace(',', '.') + "</QUANTITY>"
                          + "\n                <PRICE>" + Transaction.BirimFiyat.ToString().Replace(',', '.') + "</PRICE> "
                          + "\n                <TOTAL>" + Transaction.Toplam.ToString().Replace(',', '.') + "</TOTAL>"
                          + "\n                <VAT_RATE>" + Transaction.Kdv.ToString().Replace(',', '.') + "</VAT_RATE>"
                          + "\n                <VAT_INCLUDED>" + Transaction.KdvHaricmi0 + "</VAT_INCLUDED> "
                          + "\n                <TRANS_DESCRIPTION>" + Transaction.SatirAciklamasi + "</TRANS_DESCRIPTION>"
                          + "\n                <DUE_DATE>" + Baslik.Tarih + "</DUE_DATE>"
                          + "\n                <UNIT_CODE>" + Transaction.Birim + "</UNIT_CODE>"
                          + "\n                <UNIT_CONV1>1</UNIT_CONV1><UNIT_CONV2>2</UNIT_CONV2> "
                          + "\n                <SALESMAN_CODE>" + Baslik.SatisElemaniKodu + "</SALESMAN_CODE>"
                          + "\n                <MULTI_ADD_TAX>0</MULTI_ADD_TAX><EDT_CURR>1</EDT_CURR> "
                          + "\n                <SOURCE_WH>" + Ambar + "</SOURCE_WH>"
                          + "\n                <DETAILS>"
                          + "\n                </DETAILS>"
                          + "\n              </TRANSACTION>";

                    }
                    if (Transaction.SatirTipi == 2)
                    {
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("TYPE").Value = Transaction.SatirTipi;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("MASTER_CODE").Value = "";
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("QUANTITY").Value = "0";
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("DISCOUNT_RATE").Value = Transaction.IndirimOrani.ToString().Replace(',', '.');
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("TOTAL").Value = Transaction.Toplam.ToString().Replace(',', '.');
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("TRANS_DESCRIPTION").Value = Transaction.SatirAciklamasi;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("SALESMAN_CODE").Value = Baslik.SatisElemaniKodu;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("DETAILS").Value = "";
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("SOURCE_WH").Value = Ambar;
                        DataXml = DataXml
                          + "\n              <TRANSACTION>"
                          + "\n                <TYPE>" + Transaction.SatirTipi + "</TYPE> "
                          + "\n                <MASTER_CODE></MASTER_CODE>"
                          + "\n                <DISCOUNT_RATE>" + Transaction.IndirimOrani.ToString().Replace(',', '.') + "</DISCOUNT_RATE>"
                          + "\n                <QUANTITY>0</QUANTITY>"
                          + "\n                <TOTAL>" + Transaction.Toplam.ToString().Replace(',', '.') + "</TOTAL>"
                          + "\n                <TRANS_DESCRIPTION>" + Transaction.SatirAciklamasi + "</TRANS_DESCRIPTION>"
                          + "\n                <SALESMAN_CODE>" + Baslik.SatisElemaniKodu + "</SALESMAN_CODE>"
                          + "\n                <DETAILS></DETAILS>"
                          + "\n                <SOURCE_WH>" + Ambar + "</SOURCE_WH>"
                          + "\n              </TRANSACTION>";
                    }

                    if (Transaction.SatirTipi == 4)
                    {
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("TYPE").Value = Transaction.SatirTipi;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("MASTER_CODE").Value = Transaction.MalzemeKodu;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("PRICE").Value = Transaction.BirimFiyat.ToString().Replace(',', '.');
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("UNIT_CODE").Value = Transaction.Birim;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("QUANTITY").Value = Transaction.Miktar;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("TOTAL").Value = Transaction.Toplam.ToString().Replace(',', '.');
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("TRANS_DESCRIPTION").Value = Transaction.SatirAciklamasi;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("DUE_DATE").Value = Baslik.Tarih;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("SALESMAN_CODE").Value = Baslik.SatisElemaniKodu;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("DETAILS").Value = "";
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("SOURCE_WH").Value = Ambar;
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("VAT_RATE").Value = Transaction.Kdv.ToString().Replace(',', '.');
                        transactionstransaction[transactionstransaction.Count() - 1].FieldByName("VAT_INCLUDED").Value = Transaction.KdvHaricmi0;
                        DataXml = DataXml
                         + "\n              <TRANSACTION>"
                         + "\n                <TYPE>" + Transaction.SatirTipi + "</TYPE> "
                         + "\n                <MASTER_CODE>" + Transaction.MalzemeKodu + "</MASTER_CODE>"
                         + "\n                <PRICE>" + Transaction.BirimFiyat.ToString().Replace(',', '.') + "</PRICE> "
                         + "\n                <UNIT_CODE>" + Transaction.Birim + "</UNIT_CODE>"
                         + "\n                <QUANTITY>" + Transaction.Miktar.ToString().Replace(',', '.') + "</QUANTITY>"
                         + "\n                <TOTAL>" + Transaction.Toplam.ToString().Replace(',', '.') + "</TOTAL>"
                         + "\n                <TRANS_DESCRIPTION>" + Transaction.SatirAciklamasi + "</TRANS_DESCRIPTION>"
                         + "\n                <DUE_DATE>" + Baslik.Tarih + "</DUE_DATE>"
                         + "\n                <SALESMAN_CODE>" + Baslik.SatisElemaniKodu + "</SALESMAN_CODE>"
                         + "\n                <VAT_RATE>" + Transaction.Kdv.ToString().Replace(',', '.') + "</VAT_RATE>"
                         + "\n                <VAT_INCLUDED>" + Transaction.KdvHaricmi0 + "</VAT_INCLUDED> "
                         + "\n                <SOURCE_WH>" + Ambar + "</SOURCE_WH>"
                         + "\n                <DETAILS>"
                         + "\n                </DETAILS>"
                         + "\n              </TRANSACTION>";
                    }
                }
                DataXml = DataXml
                          + "\n            </TRANSACTIONS>"
                          + "\n            <DEFNFLDSLIST></DEFNFLDSLIST>"
                          + "\n            <DEMANDPEGGINGS></DEMANDPEGGINGS>"
                          + "\n          </ORDER_SLIP>"
                          + "\n</SALES_ORDERS>";
                if (item.Post())
                {

                    retMesaj = "OK " + DataRef;

                }
                else
                {
                    dosyayaYaz(DataXml);
                    //retMesaj += DataXml;
                    if (item.ErrorCode != 0)
                    {
                        retMesaj += "DB Error : (" + item.ErrorCode.ToString() + ") - " + item.ErrorDesc + " " + DataXml;
                    }
                    else if (item.ValidateErrors.Count > 0)
                    {

                        for (int i = 0; i < item.ValidateErrors.Count - 1; i++)
                        {
                            retMesaj += ("XML Error : (" + item.ValidateErrors[i].ID.ToString() + ") - " + item.ValidateErrors[i].Error) + " \n";
                        }
                    }

                    if (retMesaj == "")
                    {
                        retMesaj = "Sipariş İçeri Alınamadı Lütfen Carinin Risk Durumunu Kontrol Ediniz.\n" + DataXml;
                    }
                }
                obj.Disconnect();
        #region
                //WCFService.SvcClient LoClient = new WCFService.SvcClient();
                //LoClient.Open();
                //DataXml = "  <?xml version=\"1.0\" encoding=\"ISO-8859-9\"?>  "
                //           + "\n         <SALES_ORDERS> "
                //           + "\n           <ORDER_SLIP DBOP=\"INS\">"
                //           + "\n             <NUMBER>~</NUMBER> "
                //           + "\n             <WITH_PAYMENT>1</WITH_PAYMENT> "
                //           + "\n             <DOC_TRACK_NR>" + Baslik.DokumanIzlemeNumarasi + "</DOC_TRACK_NR>"
                //           + "\n             <DATE>" + Baslik.Tarih + "</DATE>"
                //           + "\n             <TIME>" + UzunTime + "</TIME>"
                //           + "\n             <AUTH_CODE>" + Baslik.YetkiKodu + "</AUTH_CODE>"
                //           + "\n             <ARP_CODE>" + CariKod + "</ARP_CODE> "
                //           + "\n             <SHIPLOC_CODE>" + SevkAdresiKodu + "</SHIPLOC_CODE> "
                //           + "\n             <NOTES1>" + Baslik.Aciklama1 + "</NOTES1> "
                //           + "\n             <ITEXT>" + Baslik.Aciklama1 + ' ' + Baslik.Aciklama2 + ' ' + Baslik.Aciklama3 + ' ' + Baslik.Aciklama4 + "</ITEXT> "
                //           + "\n             <ORDER_STATUS>1</ORDER_STATUS> "
                //           + "\n              <AUXIL_CODE>" + Baslik.OzelKod + "</AUXIL_CODE>"
                //           + "\n              <PAYMENT_CODE>" + Baslik.OdemeTipiKodu + "</PAYMENT_CODE> "
                //           + "\n              <SALESMAN_CODE>" + Baslik.SatisElemaniKodu + "</SALESMAN_CODE> "
                //           + "\n              <PROJECT_CODE>" + Baslik.ProjeKodu + "</PROJECT_CODE> "
                //           + "\n              <SHIPMENT_TYPE>" + Baslik.TeslimSekliKodu + "</SHIPMENT_TYPE> "
                //           + "\n              <TRADING_GRP>" + Baslik.TicariIslemGrubu + "</TRADING_GRP> "
                //           + "\n              <CUST_ORD_NO>" + Baslik.MusteriSiparisNo + "</CUST_ORD_NO> "
                //           + "\n              <OFFER_REFERENCE>" + Baslik.SozlesmeReferansi + "</OFFER_REFERENCE> "
                //           + "\n              <DIVISION>0</DIVISION>"
                //           + "\n              <DEPARTMENT>0</DEPARTMENT>"
                //           + "\n              <FACTORY>0</FACTORY>"
                //           + "\n              <SOURCE_WH>" + Ambar + "</SOURCE_WH>";



                //if (AcceptEInv == "1")
                //{
                //    DataXml = DataXml
                //          + "\n             <EINVOICE>1</EINVOICE> <EINVOICE_PROFILEID>" + ProfileId + "</EINVOICE_PROFILEID>";
                //}
                //else
                //{
                //    DataXml = DataXml
                //        + "\n             <EINVOICE>2</EINVOICE>  <EARCHIVEDETR_SENDMOD>2</EARCHIVEDETR_SENDMOD><EARCHIVEDETR_INTPAYMENTTYPE>4</EARCHIVEDETR_INTPAYMENTTYPE> ";
                //}


                //DataXml = DataXml + "\n            <TRANSACTIONS>";
                //foreach (M2BWCFTransaction Transaction in Transactions)
                //{

                //    if (Transaction.SatirTipi == 0)
                //    {
                //        DataXml = DataXml
                //           + "\n              <TRANSACTION>"
                //           + "\n                <TYPE>" + Transaction.SatirTipi + "</TYPE> "
                //           + "\n                <MASTER_CODE>" + Transaction.MalzemeKodu + "</MASTER_CODE>"
                //           + "\n                <AUXIL_CODE>" + Transaction.HareketOzelKodu.Replace('.', ',') + "</AUXIL_CODE>"
                //           + "\n                <QUANTITY>" + Transaction.Miktar.ToString().Replace(',', '.') + "</QUANTITY>"
                //           + "\n                <PRICE>" + Transaction.BirimFiyat.ToString().Replace(',', '.') + "</PRICE> "
                //           + "\n                <TOTAL>" + Transaction.Toplam.ToString().Replace(',', '.') + "</TOTAL>"
                //           + "\n                <VAT_RATE>" + Transaction.Kdv.ToString().Replace(',', '.') + "</VAT_RATE>"
                //           + "\n                <VAT_INCLUDED>" + Transaction.KdvHaricmi0 + "</VAT_INCLUDED> "
                //           + "\n                <TRANS_DESCRIPTION>" + Transaction.SatirAciklamasi + "</TRANS_DESCRIPTION>"
                //           + "\n                <UNIT_CODE>" + Transaction.Birim + "</UNIT_CODE>"
                //           + "\n                <UNIT_CONV1>1</UNIT_CONV1><UNIT_CONV2>1</UNIT_CONV2> "
                //           + "\n                <SALESMAN_CODE>" + Baslik.SatisElemaniKodu + "</SALESMAN_CODE>"
                //           + "\n                <MULTI_ADD_TAX>0</MULTI_ADD_TAX><EDT_CURR>1</EDT_CURR> "
                //           + "\n                <SOURCE_WH>" + Ambar + "</SOURCE_WH>"
                //           + "\n                <DETAILS>"
                //           + "\n                </DETAILS>"
                //           + "\n              </TRANSACTION>";
                //    }

                //    if (Transaction.SatirTipi == 2)
                //    {
                //        // double tutar = Transaction.Toplam;

                //        if (Transaction.Toplam < 0)
                //        {
                //            Transaction.Toplam = -1 * Transaction.Toplam;
                //        }
                //        DataXml = DataXml
                //           + "\n              <TRANSACTION>"
                //           + "\n                <TYPE>" + Transaction.SatirTipi + "</TYPE> "
                //           + "\n                <MASTER_CODE></MASTER_CODE>"
                //           + "\n                <CALC_TYPE>1</CALC_TYPE>"
                //           + "\n                <QUANTITY>0</QUANTITY>"
                //           + "\n                <TOTAL>" + Transaction.Toplam.ToString().Replace(',', '.') + "</TOTAL>"
                //           + "\n                <TRANS_DESCRIPTION>" + Transaction.SatirAciklamasi + "</TRANS_DESCRIPTION>"
                //           + "\n                <SALESMAN_CODE>" + Baslik.SatisElemaniKodu + "</SALESMAN_CODE>"
                //           + "\n                <DETAILS></DETAILS>"
                //           + "\n                <SOURCE_WH>" + Ambar + "</SOURCE_WH>"
                //           + "\n              </TRANSACTION>";
                //    }
                //}

                //DataXml = DataXml
                //           + "\n            </TRANSACTIONS>"
                //           + "\n            <DEFNFLDSLIST></DEFNFLDSLIST>"
                //           + "\n            <DEMANDPEGGINGS></DEMANDPEGGINGS>"
                //           + "\n          </ORDER_SLIP>"
                //           + "</SALES_ORDERS>";

                ////return DataXml;

                ////DataXml = StringCompressor.ZipBase64(DataXml);


                //ParamXml =
                //   "<?xml version=\"1.0\" encoding=\"utf-16\"?>"
                //   + "<Parameters>"
                //   + "  <ReplicMode>0</ReplicMode>"
                //   + "  <CheckParams>0</CheckParams>" // 0 olsa ambar parametrelerini kontrol et / 1 pasif
                //   + "  <CheckRight>0</CheckRight>" // 0 olsa yetkiler aktif / 1 pasif
                //   + "  <ApplyCampaign>0</ApplyCampaign>" // kampanya
                //   + "  <ApplyCondition>0</ApplyCondition>" // satış koşulu
                //   + "  <FillAccCodes>0</FillAccCodes>" // muhasebe kodlarını doldur
                //   + "  <FormSeriLotLines>0</FormSeriLotLines>" // 
                //   + "  <GetStockLinePrice>0</GetStockLinePrice>" // son satırın istenilen fiyat bilgisini otomatik set etmek için kullanılır
                //   + "  <ExportAllData>0</ExportAllData>" // 
                //   + "  <Validation>1</Validation>" // 1: logoobject doğrulama yapar, 0 doğrulama yapmaz
                //   + "</Parameters>";

                //// ParamXml = "";

                //LoClient.AppendDataObject(DataType, ref DataRef, ref DataXml, ref ParamXml, ref ErrorStr, ref Status, LbsLoadSecurityCode, FirmNr, SecurityCode);
                //if (Status == 4)
                //{
                //    retMesaj = ErrorStr + "\r" + DataXml;
                //}
                //else
                //{
                //    retMesaj = "OK " + DataRef.ToString();
                //}
        #endregion
            }
            catch (Exception ex)
            {
                if (obj.LoggedIn)
                {
                    obj.Disconnect();
                    return "Objeye Bağlanılamadı";
                }
                retMesaj = "Siparişi Oluştur kısmında hata!\n" + ex.ToString();

            }




            return retMesaj;
        }

    }
}
