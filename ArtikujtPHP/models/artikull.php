<?php
    class Artikull{
        public bool $isNew;
        public int $id;
        public string $emri;
        public string $njesia;
        public DateTime $dataSkadences;
        public float $cmimi;
        public string $lloj;
        public bool $kaTvsh;
        public string $tipi;
        public string $barkod;
    }

    class Lloj {
        public const I = "I"; //Importuar
        public const V = "V"; //Vendi
    }

    class Tipi {
        public const None = "none";
        public const Ushqimore = "Ushqimore";
        public const Bulmet = "Bulmet";
        public const Pije = "Pije";
        public const Embelsire = "Embelsire";
    }
?>