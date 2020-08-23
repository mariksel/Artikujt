package com.example.artikujt;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;

import com.example.artikujt.models.Artikull;
import com.example.artikujt.models.InvalidStateException;
import com.example.artikujt.models.Lloj;
import com.example.artikujt.models.Tipi;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.snackbar.Snackbar;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.text.Editable;
import android.text.TextWatcher;
import android.transition.Visibility;
import android.view.View;

import android.view.Menu;
import android.view.MenuItem;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;


public class ArtikullActivity extends AppCompatActivity {

    private static Artikull artikull = CreateNewArtikull();
    public static void setArtikull(Artikull _artikull){
        artikull = _artikull;
    }
    public static Artikull CreateNewArtikull(){
        Artikull _artikull = new Artikull();
        _artikull.isNew = true;
        setArtikull(_artikull);
        return _artikull;
    }

    final Calendar dataSkadencesCalendar = Calendar.getInstance();
    EditText emriEditText;
    EditText njesiaEditText;
    EditText dataSkadencesEditText;
    EditText cmimiEditText;
    RadioGroup llojRadioGroup;
    RadioButton importuarRadioButton;
    RadioButton vendiRadioButton;
    CheckBox kaTvshCheckBox;
    Spinner tipiSpiner;
    EditText barkodEditText;

    Button artikullIRiButton;
    Button kerkoButton;
    Button ruajButton;
    Button fshiButton;

    static ArtikullActivity thisActivity;
    ArrayAdapter<Tipi> tipiArrayAdapter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        thisActivity = this;

        setContentView(R.layout.activity_artikull);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        emriEditText = findViewById(R.id.emriEditText);
        njesiaEditText = findViewById(R.id.njesiaEditText);
        dataSkadencesEditText = findViewById(R.id.dataSkadencesEditText);
        cmimiEditText = findViewById(R.id.cmimiEditText);
        llojRadioGroup = findViewById(R.id.llojRadioGroup);
        importuarRadioButton = findViewById(R.id.importuarRadioButton);
        vendiRadioButton = findViewById(R.id.vendiRadioButton);
        kaTvshCheckBox = findViewById(R.id.kaTvshCheckBox);
        tipiSpiner = (Spinner) findViewById(R.id.tipiSpinner);
        barkodEditText = findViewById(R.id.barkodEditText);

        artikullIRiButton = findViewById(R.id.artikullIRiButton);
        kerkoButton = findViewById(R.id.kerkoButton);
        ruajButton = findViewById(R.id.ruajButton);
        fshiButton = findViewById(R.id.fshiButton);

        final DatePickerDialog.OnDateSetListener date = new DatePickerDialog.OnDateSetListener() {

            @Override
            public void onDateSet(DatePicker view, int year, int monthOfYear,
                                  int dayOfMonth) {
                dataSkadencesCalendar.set(Calendar.YEAR, year);
                dataSkadencesCalendar.set(Calendar.MONTH, monthOfYear);
                dataSkadencesCalendar.set(Calendar.DAY_OF_MONTH, dayOfMonth);
                updateDataSkadences();
            }

        };

        tipiArrayAdapter = new ArrayAdapter<Tipi>(this, R.layout.spiner_item, Tipi.values());
        tipiSpiner.setAdapter(tipiArrayAdapter);

        FloatingActionButton fab = findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        emriEditText.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void afterTextChanged(Editable editable) {
                artikull.emri = emriEditText.getText().toString();
            }
        });
        njesiaEditText.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void afterTextChanged(Editable editable) {
                artikull.njesia = editable.toString();
            }
        });
        dataSkadencesEditText.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                new DatePickerDialog(ArtikullActivity.this, date, 2020, 2, 1).show();
            }
        });
        cmimiEditText.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void afterTextChanged(Editable editable) {
                String numText = editable.toString();
                if(numText.isEmpty()){
                    artikull.cmimi = 0;
                } else {
                    try{
                        artikull.cmimi = Double.parseDouble(numText);
                    } catch(NumberFormatException e) {
                        cmimiEditText.setText(String.valueOf(artikull.cmimi));
                    }
                }

            }
        });
        llojRadioGroup.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup radioGroup, int i) {
                if(importuarRadioButton.isChecked()){
                    artikull.lloj = Lloj.I;
                }
                else if(vendiRadioButton.isChecked()){
                    artikull.lloj = Lloj.V;
                }
            }
        });

        kaTvshCheckBox.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                artikull.kaTvsh = b;
            }
        });

        tipiSpiner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                Tipi tipi = (Tipi)tipiSpiner.getItemAtPosition(i);

                 artikull.tipi = tipi;
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }

        });

        barkodEditText.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void afterTextChanged(Editable editable) {
                artikull.barkod = editable.toString();
            }
        });

        artikullIRiButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                CreateNewArtikull();
                Reset();
            }
        });

        kerkoButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(thisActivity, KerkoActivity.class);
                startActivity(intent);
            }
        });

        ruajButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                try {
                    artikull.validate();
                } catch (InvalidStateException e) {
                    Toast.makeText(ArtikullActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    return;
                }

                Repository repo = new Repository(ArtikullActivity.this);

                boolean succeeded = false;
                if(artikull.isNew){
                    succeeded = repo.addArtikull(artikull);
                } else {
                    succeeded = repo.updateArtikull(artikull);
                }
                if(succeeded){
                    CreateNewArtikull();
                    Reset();
                }

                if(succeeded)
                    Toast.makeText(ArtikullActivity.this, "Artikulli u ruajt me sukses", Toast.LENGTH_SHORT).show();

                else
                    Toast.makeText(ArtikullActivity.this, "Problem me ruajtjen e artikullit", Toast.LENGTH_SHORT).show();
            }
        });

        fshiButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Repository repo = new Repository(ArtikullActivity.this);
                boolean succeeded = repo.deleteArtikull(artikull);

                if(succeeded){
                    CreateNewArtikull();
                    Reset();
                    Toast.makeText(ArtikullActivity.this, "Artikulli " + artikull.emri + " u fshi me sukses", Toast.LENGTH_SHORT).show();
                }
                else
                    Toast.makeText(ArtikullActivity.this, "Problem me fshirjen e artikullit", Toast.LENGTH_SHORT).show();
            }
        });
    }

    @Override
    protected void onResume() {
        super.onResume();
        Reset();
    }

    private void Reset(){
        if(artikull.isNew){
            fshiButton.setVisibility(View.INVISIBLE);
            emriEditText.setText(null);
            njesiaEditText.setText(null);
            dataSkadencesEditText.setText(null);
            cmimiEditText.setText("0");
            importuarRadioButton.setChecked(false);
            llojRadioGroup.clearCheck();
            kaTvshCheckBox.setChecked(false);
            tipiSpiner.setSelection(tipiArrayAdapter.getPosition(Tipi.NONE));
            barkodEditText.setText(null);
        } else {
            fshiButton.setVisibility(View.VISIBLE);
            emriEditText.setText(artikull.emri);
            njesiaEditText.setText(artikull.njesia);
            if(artikull.dataSkadences != null){
                dataSkadencesCalendar.setTime(artikull.dataSkadences);
                updateDataSkadences();
            }

            cmimiEditText.setText(String.valueOf(artikull.cmimi));
            importuarRadioButton.setChecked(artikull.lloj == Lloj.I);
            vendiRadioButton.setChecked(artikull.lloj == Lloj.V);
            kaTvshCheckBox.setChecked(artikull.kaTvsh);
            tipiSpiner.setSelection(tipiArrayAdapter.getPosition(artikull.tipi));
            barkodEditText.setText(artikull.barkod);
        }
    }


    private void updateDataSkadences() {
        String myFormat = "dd/MM/yyyy";
        SimpleDateFormat sdf = new SimpleDateFormat(myFormat, Locale.US);
        artikull.dataSkadences = dataSkadencesCalendar.getTime();
        dataSkadencesEditText.setText(sdf.format(dataSkadencesCalendar.getTime()));
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {
        MenuItem item= menu.findItem(R.id.action_settings);
        item.setVisible(false);
        super.onPrepareOptionsMenu(menu);
        return true;
    }
}