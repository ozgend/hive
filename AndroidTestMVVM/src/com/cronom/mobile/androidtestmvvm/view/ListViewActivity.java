package com.cronom.mobile.androidtestmvvm.view;

import android.os.Bundle;
import android.util.Log;

import com.cronom.mobile.androidtestmvvm.R;
import com.cronom.mobile.androidtestmvvm.interfaces.BaseActivity;
import com.cronom.mobile.androidtestmvvm.interfaces.SelectionObserver;
import com.cronom.mobile.androidtestmvvm.model.ConcertListViewModel;

public class ListViewActivity extends BaseActivity implements SelectionObserver {

	ConcertListViewModel	concertListViewModel;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		concertListViewModel = new ConcertListViewModel(this);
		super.bind(R.layout.activity_listview, concertListViewModel);
	}

	public void itemSelected(Object item) {
		Log.i("SelectionObserver.itemSelected", item.toString());
	}

}
