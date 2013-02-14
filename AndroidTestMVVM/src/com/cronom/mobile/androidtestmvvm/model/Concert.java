package com.cronom.mobile.androidtestmvvm.model;

import gueei.binding.observables.StringObservable;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

public class Concert {

	public StringObservable	Hall;
	public StringObservable	DateString;
	public StringObservable	Band;
	public int				Id;

	public Concert() {
	}

	public Concert(String hall, Date date, String band, int id) {
		this.Hall = new StringObservable(hall);
		this.DateString = new StringObservable(new SimpleDateFormat("MMMM d, yyyy", Locale.US).format(date).toString());
		this.Band = new StringObservable(band);
		this.Id = id;
	}

}
