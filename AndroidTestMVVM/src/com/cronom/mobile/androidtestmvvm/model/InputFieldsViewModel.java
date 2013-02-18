package com.cronom.mobile.androidtestmvvm.model;

import gueei.binding.Observable;

public class InputFieldsViewModel {

	public Observable<InputData> InputDataItem;
		
	public InputFieldsViewModel() {
		this.InputDataItem = new Observable<InputData>(InputData.class, new InputData());
	}
	
}
