package com.example.artikujt;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;

import com.example.artikujt.models.Artikull;

import java.util.Collections;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

public class KerkoActivity extends AppCompatActivity {

    public List<Artikull> artikujt;

    Button dilButton;
    ListView artikujtListView;

    KerkoActivity thiActivity;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        thiActivity = this;
        setContentView(R.layout.activity_kerko);
        ActionBar actionBar=getSupportActionBar();
        actionBar.hide();

        dilButton = findViewById(R.id.dilButton);
        artikujtListView = findViewById(R.id.artikujtListView);



        dilButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ArtikullActivity.CreateNewArtikull();
                thiActivity.finish();
            }
        });
    }

    @Override
    protected void onResume() {
        super.onResume();
        Repository repo = new Repository(this);
        artikujt = repo.artikujt();

        showListViewWithArtikujt();
    }

    private void showListViewWithArtikujt(){
        Artikull[] artikujtAsArray = artikujt.toArray(new Artikull[artikujt.size()]);
        ArtikullAdapter aAdapter = new ArtikullAdapter(this, artikujtAsArray);
        artikujtListView.setAdapter(aAdapter);
    }
}