using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IZOKALE_WEBSERVICE.Models
{
    public class Classes
    {
    }

    public class CariSevkAdresi
    {
        public string AdresBasligi { get; set; }
        public string Aciklama1 { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
    }
    public class M2BWCFBaslik
    {

        public string Tarih { get; set; }
        public string CariLREF { get; set; }
        public string BelgeNo { get; set; }
        public string OzelKod { get; set; }
        public string YetkiKodu { get; set; }

        //<SHIPLOC_CODE>02</SHIPLOC_CODE> sevkiyat adresinin kodu
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public string Aciklama3 { get; set; }
        public string Aciklama4 { get; set; }
        public string OdemeTipiKodu { get; set; }
        public string TicariIslemGrubu { get; set; }
        public string SatisElemaniKodu { get; set; }
        public string TeslimSekliKodu { get; set; }
        public string ProjeKodu { get; set; }
        public string MusteriSiparisNo { get; set; }
        public string DokumanIzlemeNumarasi { get; set; }
        public int SozlesmeReferansi { get; set; }

        public string Isyeri { get; set; }
        public string Bolum { get; set; }
        public string Fabrika { get; set; }
        public string Ambar { get; set; }





    }




    public class M2BWCFTransaction
    {

        public int SatirTipi { get; set; }
        public string MalzemeKodu { get; set; }
        public string HareketOzelKodu { get; set; }
        public double Miktar { get; set; }
        public double BirimFiyat { get; set; }
        public double Toplam { get; set; }
        public double IskontoOrani { get; set; }
        public double Kdv { get; set; }
        public int KdvHaricmi0 { get; set; } //            VAT_INCLUDED
        public string SatirAciklamasi { get; set; }
        public string Birim { get; set; }
    }




    public class WCFIsYeri
    {
        public string IsYeriKodu;
        public string IsYeriAciklamasi;
    }
    public class WCFFabrika
    {
        public string FabrikaKodu;
        public string FabrikaAciklamasi;
    }
    public class WCFBolum
    {
        public string BolumKodu;
        public string BolumAciklamasi;
    }
    public class WCFAmbar
    {
        public string AmbarKodu;
        public string AmbarAciklamasi;
    }
    public class WCFOdemePlani
    {
        public string OdemePlaniKodu;
        public string OdemePlaniAciklamasi;
    }


    public class WCFSatisElemani
    {
        public string SatisElemaniKodu;
        public string SatisElemaniAciklamasi;
    }



    public class Musteriler
    {
        public string LOGICALREF;
        public string BayiAdi;
        public string BayiKodu;
        public string ADDR1;
        public string ADDR2;
        public string CITY;
        public string TOWN;
        public string WEBURL;
        public string TELNR1;
        public string TELNR2;
    }

    public class MusteriyeBagliCariler
    {
        public string LOGICALREF;
        public string ARPREF;
        public string CariKodu;
        public string CariAdi;

    }

    public class IlBilgileri
    {
        public string LOGICALREF;
        public string IlAdi;
        public string IlKodu;
        public List<IlceBilgileri> Ilceler;
    }

    public class IlceBilgileri
    {

        public string LOGICALREF;
        public string IlKodu;
        public string IlceAdi;

    }



    public class HesapOzeti
    {
        public string Kodu;
        public string Unvani;
        public string Aciklama;

        public string Borc;
        public string Alacak;
        public string Bakiye;

    }

    public class FiyatListesiBakiye
    {
        public string fiyatListesiKodu;
        public string Aciklama;
        public string baglantiTutari;
        public string siparisTutari;
        public string bakiye;
        public string baglantiLREF;
    }
    public class SiparisFis
    {
        public int orFicheRef;
        //public string Statu;
        public string cariAdi;
        public string siparisNo;
        public string portalKodu;
        public DateTime siparisTarihi;
        public string siparisDurumu; // Tamamen sevkedilmi, kısmi sevk, bekliyor
        //public string projeKodu;
        public string fiyatListesi;
        public string siparisTutari;
        public string sevkedilenTutar;
      
        //public string adresBilgisi;
        public string aciklamalar;


    }

    public class SiparisSatir
    {
        public int orfLineRef;
        public string durum;
        public string malzemeKodu;
        public string Aciklama;
        public string miktar;
        public string birim;
        public string BekleyenMiktar;
        public string birimFiyatKdvDahil;


        public string Tutar;
    }
    public class SiparisSatirIrsaliye
    {
        public int stlineRef;
        public string irsaliyeNo;
        public DateTime irsaliyeTarihi;
        public string miktar;
        public string birim;
        public string FaturaNo;
        public string IrsaliyeAciklama;
    }
    public class IrsaliyeFis
    {
        public int stFicheRef;
        public string cariAdi;
        public string irsaliyeNo;

        public DateTime irsaliyeTarihi;
        //public string projeKodu;
        //public string Sofor;
        public string aciklamalar;
        public string fiyatListesi;
        public string faturaNo;
        
    }

    public class IrsaliyeSatir
    {
        public int stLineRef;
        public string malzemeKodu;
        public string malzemeAdi;
        public string miktar;
        public string birim;
    }
    public class HesapEkstresi
    {
        public string firma;
        public DateTime Tarih;
        public string IslemTipi;
        public string BelgeNo;
        public string OdemeTipi;
        public double Borc;
        public double Alacak;
        public double Bakiye;



        public string Aciklama;
        public string SiparisNo;
        public string Detay;

    }
    public class MenuBasliklari
    {
        public bool Success;
        public string HataMesaji;
        public string OzelKod;
        public string MenuAdi;
        public List<AltMenuBasliklari> AltMenuler;
    }

    public class AltMenuBasliklari
    {

        public string AltMenuOzelKod;
        public string AltMenuAdi;

    }

    public class NakliyeBilgileri
    {
        public int LOGICALREF;
        public bool Statu;
        public string NakliyeKodu;
        public string NakliyeAdi;
        public string NakliyeBirimSeti;
        public double NakliyeBirimFiyatiTL;
        public int NakliyeFiyatSayisi;
        public string NakliyeHatasi;

    }

    public class Malzeme
    {
        public bool Success;
        public string HataMesaji;
        public string MalzemeKodu;
        public string MalzemeAdi;
        public string MalzemeAciklama;
        public string Birim;
        public string Marka;
        public string SPECODE1;
        public string SPECODE2;


        public double PaketKatsayi;
        public double M2Katsayi;
        public double M3Katsayi;
        public double KGKatsayi;


        public double BaseFiyat;
        public string BaseDoviz;
        public double sozlesmeUSD;
        public double sozlesmeEUR;
        public double GuncelUSD;
        public double GuncelEUR;
        public double HesaplanmisBirimFiyatiTL;
        public double NakliyeMasrafiTL;
        public double Kdv;
        public string HesaplamaDetayliAciklama;

        public int NakliyeKartiLref;
        public string NakliyeKodu;
        public string NakliyeAdi;
        public string NakliyeBirimSeti;
    }

}