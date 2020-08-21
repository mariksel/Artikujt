package com.example.artikujt.models;

import java.util.Date;

public class Artikull {
    public boolean isNew;
    public int id;
    public String emri;
    public String njesia;
    public Date dataSkadences;
    public double cmimi;
    public Lloj lloj;
    public boolean kaTvsh;
    public Tipi tipi = Tipi.NONE;
    public String barkod;

    public Artikull(int id, String emri, String njesia, Date dataSkadences, double cmimi, Lloj lloj, boolean kaTvsh, Tipi tipi, String barkod) {
        this.id = id;
        this.emri = emri;
        this.njesia = njesia;
        this.dataSkadences = dataSkadences;
        this.cmimi = cmimi;
        this.lloj = lloj;
        this.kaTvsh = kaTvsh;
        this.tipi = tipi;
        this.barkod = barkod;
    }

    public Artikull(){}

    public void validate() throws InvalidStateException{
        if( isNullOrWhiteSpace(emri))
            throw  new InvalidStateException("Emri duhet plotesuar");
        if(isNullOrWhiteSpace(njesia))
            throw  new InvalidStateException("Njesia duhet plotesuar");
        if(dataSkadences == null)
            throw  new InvalidStateException("Data Skadences duhet plotesuar");
        if(lloj == null)
            throw  new InvalidStateException("Lloj duhet plotesuar");
        if(tipi == null || tipi == Tipi.NONE)
            throw  new InvalidStateException("Tipi duhet plotesuar");
        if(isNullOrWhiteSpace(barkod))
            throw  new InvalidStateException("Barkod duhet plotesuar");
    }

    private boolean isNullOrWhiteSpace(String str){
        return str == null || str.trim().isEmpty();
    }


    @Override
    public String toString() {
        return emri ;
    }
}
