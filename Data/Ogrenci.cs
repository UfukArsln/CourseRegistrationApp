using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Ogrenci
    {
        [Key]
        [DisplayName("Öğrenci Id")]
        public int OgrenciId { get; set; }

        [DisplayName("Öğrenci Ad")]
        public string? OgrenciAd { get; set; }

        [DisplayName("Öğrenci Soyad")]
        public string? OgrenciSoyad { get; set; }

        public string AdSoyad
        {
            get
            {
                return this.OgrenciAd + " " + this.OgrenciSoyad;
            }
        }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}