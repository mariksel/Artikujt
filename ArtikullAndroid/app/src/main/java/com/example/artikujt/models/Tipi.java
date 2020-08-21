package com.example.artikujt.models;

public enum Tipi {
    NONE( "Zgjidhni tipin" ),
    Ushqimore( "Ushqimore" ),
    Bulmet( "Bulmet" ),
    Pije( "Pije" ),
    Embelsire( "Embelsire" );

    private String value;
    Tipi(String tipi) {
        value = tipi;
    }


    @Override
    public String toString() {
        return value;
    }
}
