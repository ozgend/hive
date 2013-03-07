package com.cronom.mobile.androidtestmvvm;

import gueei.binding.Binder;
import android.app.Application;

public class MVVMTestApp extends Application {

	@Override
	public void onCreate() {
		super.onCreate();
		Binder.init(this);
	}
}
