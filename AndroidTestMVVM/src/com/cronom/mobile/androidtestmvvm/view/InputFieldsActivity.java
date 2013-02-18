package com.cronom.mobile.androidtestmvvm.view;

import gueei.binding.app.BindingActivity;
import android.os.Bundle;

import com.cronom.mobile.androidtestmvvm.R;
import com.cronom.mobile.androidtestmvvm.model.InputFieldsViewModel;

public class InputFieldsActivity extends BindingActivity {

	InputFieldsViewModel	inputFieldsViewModel;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		inputFieldsViewModel = new InputFieldsViewModel();
		//super.bind(R.layout.activity_inputfields, inputFieldsViewModel);
		this.setAndBindRootView(R.layout.activity_inputfields, inputFieldsViewModel);
	}

}
