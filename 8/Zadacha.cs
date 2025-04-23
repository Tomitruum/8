using System.Runtime.Serialization;

namespace _8
{
    [DataContract]
    public class Zadacha
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Opisanie { get; set; }

        [DataMember]
        public DateTime Data { get; set; }

        [DataMember]
        public bool Vazhno { get; set; }

        [DataMember]
        public double DlitelnostChasov { get; set; }

        public Zadacha() { }

        public Zadacha(int id, string opisanie, DateTime data, bool vazhno, double dlitelnostChasov)
        {
            Id = id;
            Opisanie = opisanie;
            Data = data;
            Vazhno = vazhno;
            DlitelnostChasov = dlitelnostChasov;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Описание: {Opisanie}, Дата: {Data.ToString("dd-MM-yyyy")}, Важная: {Vazhno}, Длительность: {DlitelnostChasov} ч.";
        }
    }
}

