package com.example.artikujt;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.artikujt.models.Artikull;

public class ArtikullAdapter extends ArrayAdapter<Artikull> implements View.OnClickListener{
    private Artikull[] artikujt;
    KerkoActivity kerkoActivity;



    private static class ViewHolder {
        TextView artikullItemId;
        TextView artikullItemEmri;
        TextView artikullItemCmimi;
    }

    public ArtikullAdapter(@NonNull KerkoActivity context, @NonNull Artikull[] _artikujt) {
        super(context, R.layout.artikull_list_item, R.id.artikullItemEmri, _artikujt);
        this.artikujt = _artikujt;
        this.kerkoActivity = context;
    }

    @Override
    public void onClick(View view) {
        ViewHolder viewHolder = (ViewHolder) view.getTag();
        ArtikullActivity.setArtikull((Artikull) viewHolder.artikullItemId.getTag());
        kerkoActivity.finish();
    }


    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {

        Artikull artikull = getItem(position);
        ViewHolder viewHolder;

        final View result;

        if(convertView == null){
            viewHolder = new ViewHolder();
            LayoutInflater inflater = LayoutInflater.from(getContext());
            convertView = inflater.inflate(R.layout.artikull_list_item, parent, false);
            viewHolder.artikullItemId = (TextView) convertView.findViewById(R.id.artikullItemId);
            viewHolder.artikullItemEmri = (TextView) convertView.findViewById(R.id.artikullItemEmri);
            viewHolder.artikullItemCmimi = (TextView) convertView.findViewById(R.id.artikullItemCmimi);

            result=convertView;
            convertView.setTag(viewHolder);

        } else {
            viewHolder = (ViewHolder) convertView.getTag();
            result = convertView;
        }

        viewHolder.artikullItemId.setText(String.valueOf( artikull.id));
        viewHolder.artikullItemEmri.setText(artikull.emri);
        viewHolder.artikullItemCmimi.setText( String.valueOf( artikull.cmimi) );
        convertView.setOnClickListener(this);
        viewHolder.artikullItemId.setTag(artikull);

        return super.getView(position, convertView, parent);
    }
}
