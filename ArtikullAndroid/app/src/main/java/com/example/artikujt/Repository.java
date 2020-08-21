package com.example.artikujt;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

import com.example.artikujt.models.Artikull;
import com.example.artikujt.models.Lloj;
import com.example.artikujt.models.Tipi;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Repository extends SQLiteOpenHelper {
    public static final String ARTIKUJT = "Artikujt";
    public static final String ID = "Id";
    public static final String EMRI = "Emri";
    public static final String NJESIA = "NJESIA";
    public static final String DATA_SKADENCES = "DataSkadences";
    public static final String CMIMI = "Cmimi";
    public static final String LLOJ = "Lloj";
    public static final String KA_TVSH = "KaTvsh";
    public static final String TIPI = "Tipi";
    public static final String BARKOD = "Barkod";

    public Repository(@Nullable Context context) {
        super(context, "artikujt.db", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String crateTableStatement  = "CREATE TABLE " + ARTIKUJT + " (" + ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " + EMRI + " TEXT, " + NJESIA + " TEXT, " + DATA_SKADENCES + " TEXT," +
                CMIMI + " REAL, " + LLOJ + " TEXT, " + KA_TVSH + " INTEGER, " + TIPI + " TEXT, " + BARKOD + " TEXT )";

        db.execSQL(crateTableStatement);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {

    }

    private ContentValues artikullContentValues(Artikull artikull){
        ContentValues cv = new ContentValues();

        cv.put(EMRI, artikull.emri);
        cv.put(NJESIA, artikull.njesia);
        cv.put(DATA_SKADENCES, artikull.dataSkadences.toString());
        cv.put(CMIMI, artikull.cmimi);
        cv.put(LLOJ, artikull.lloj.toString());
        cv.put(KA_TVSH, artikull.kaTvsh);
        cv.put(TIPI, artikull.tipi.toString());
        cv.put(BARKOD, artikull.barkod);

        return cv;
    }

    public boolean addArtikull(Artikull artikull){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues cv = artikullContentValues(artikull);

        long insert = db.insert(ARTIKUJT, null, cv);

        db.close();

        return insert > -1;
    }

    public boolean updateArtikull(Artikull artikull){
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues cv = artikullContentValues(artikull);
        String where = ID + " = " + artikull.id;
        int update = db.update(ARTIKUJT, cv, where, null);

        db.close();

        return update > -1;
    }

    public boolean deleteArtikull(Artikull artikull){
        SQLiteDatabase db = this.getWritableDatabase();

        String where = ID + " = " + artikull.id;
        int delete = db.delete(ARTIKUJT, where, null);

        db.close();

        return delete > -1;
    }

    public List<Artikull> artikujt(){
        List<Artikull> list = new ArrayList<Artikull>();

        String query = "SELECT * FROM " + ARTIKUJT + " ORDER BY "+ID+" DESC";

        SQLiteDatabase db = this.getReadableDatabase();

        Cursor cursor = db.rawQuery(query, null);

        if (cursor.moveToFirst()){
            do{
                int id = cursor.getInt(0);
                String emri = cursor.getString(1);
                String njesia = cursor.getString(2);
                String dataSkadencesText = cursor.getString(3);
                Date dataSkadences = new Date(dataSkadencesText);
                double cmimi = cursor.getDouble(4);
                String llojText = cursor.getString(5);
                Lloj lloj = Lloj.valueOf(llojText);
                boolean kaTvsh = cursor.getInt(6) == 1;
                String tipiText = cursor.getString(7);
                Tipi tipi = Tipi.valueOf(tipiText);
                String barkod = cursor.getString(8);

                Artikull artikull = new Artikull(id, emri, njesia, dataSkadences, cmimi, lloj, kaTvsh, tipi, barkod);
                list.add(artikull);

            } while(cursor.moveToNext());
        }

        cursor.close();
        db.close();

        return list;
    }
}
