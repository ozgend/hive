package com.cronom.mobile.androidtestmvvm.view;

import android.os.Bundle;

import com.cronom.mobile.androidtestmvvm.R;
import com.cronom.mobile.androidtestmvvm.interfaces.BaseActivity;
import com.cronom.mobile.androidtestmvvm.model.InputData;
import com.cronom.mobile.androidtestmvvm.model.InputFieldsViewModel;

public class InputFieldsActivity extends BaseActivity {

	public InputData inputData;
	public InputFieldsViewModel inputDataViewModel;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		this.inputData = new InputData();
		inputDataViewModel = new InputFieldsViewModel(inputData);

		super.bind(R.layout.activity_inputfields, inputDataViewModel);
	}

}
