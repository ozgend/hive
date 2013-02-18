package com.cronom.mobile.androidtestmvvm.model;

import gueei.binding.Command;
import gueei.binding.Observable;
import android.util.Log;
import android.view.View;

public class InputFieldsViewModel {

	public InputData	inputData;

	public InputFieldsViewModel(InputData _inputData) {
		inputData = new InputData();
	}

	public final Command	ProcessData	= new Command() {
											@Override
											public void Invoke(View view, Object... args) {
												Log.i("InputFieldsViewModel", inputData.toString());
											}
										};

}
