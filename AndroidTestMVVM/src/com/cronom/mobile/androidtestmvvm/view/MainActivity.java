package com.cronom.mobile.androidtestmvvm.view;

import android.os.Bundle;

import com.cronom.mobile.androidtestmvvm.BaseActivity;
import com.cronom.mobile.androidtestmvvm.R;
import com.cronom.mobile.androidtestmvvm.model.ConcertViewModel;

public class MainActivity extends BaseActivity {

	ConcertViewModel	concertViewModel;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		concertViewModel = new ConcertViewModel();
		super.bindModelToView(R.layout.activity_main, concertViewModel);		
	}

}
