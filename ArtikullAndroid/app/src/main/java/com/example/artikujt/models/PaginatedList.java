package com.example.artikujt.models;

import java.util.ArrayList;

public class PaginatedList<T> {
    public ArrayList<T> models;
    public int numberOfPages;
    public ArrayList<Page> pages;

    public PaginatedList(ArrayList<T> _models, int _numberOfPages, int currentPageIndex){
        models = _models;
        numberOfPages = _numberOfPages;

        for (int i = 1; i <= numberOfPages; i++)
        {
            pages.add(new Page(i, i == currentPageIndex));
        }
    }

    public class Page
    {
        public int index;
        public boolean isActive;

        public Page(int _index, boolean _isActive)
        {
            index = _index;
            isActive = _isActive;
        }
    }
}
