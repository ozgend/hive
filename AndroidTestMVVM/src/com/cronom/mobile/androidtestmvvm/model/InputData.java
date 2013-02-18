package com.cronom.mobile.androidtestmvvm.model;

import gueei.binding.observables.DoubleObservable;
import gueei.binding.observables.IntegerObservable;
import gueei.binding.observables.StringObservable;

public class InputData {

	public IntegerObservable	ValueInt1;
	public StringObservable		ValueString1;
	public DoubleObservable		ValueDouble1;
	public IntegerObservable	ValueInt2;
	public StringObservable		ValueString2;
	public DoubleObservable		ValueDouble2;
	public DoubleObservable		SumDouble;
	public IntegerObservable	SumInt;

	public InputData() {
		this.ValueInt1 = new IntegerObservable(1);
		this.ValueString1 = new StringObservable("text value 1");
		this.ValueDouble1 = new DoubleObservable(1.3);
		this.ValueInt2 = new IntegerObservable(2);
		this.ValueString2 = new StringObservable("text value 2");
		this.ValueDouble2 = new DoubleObservable(2.3);
	}

//	public double getSumDouble() {
//		return this.CDouble1.get() + this.CDouble2.get();
//	}
//
//	public int getSumInt() {
//		return this.CInt1.get() + this.CInt2.get();
//	}
}
