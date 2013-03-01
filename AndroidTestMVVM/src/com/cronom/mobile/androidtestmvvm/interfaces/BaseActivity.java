package com.cronom.mobile.androidtestmvvm.interfaces;

import gueei.binding.Binder;
import android.app.Activity;
import android.os.Bundle;

public class BaseActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
	}
	
	public void bind(int layoutId, Object model) {
		Binder.InflateResult result = Binder.inflateView(this, layoutId, null, false);
		Binder.bindView(this, result, model);		
		setContentView(result.rootView);
	}
}
