package com.cronom.mobile.androidtestmvvm.view;

import gueei.binding.Command;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.cronom.mobile.androidtestmvvm.R;
import com.cronom.mobile.androidtestmvvm.interfaces.BaseActivity;

public class MainActivity extends BaseActivity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		super.bind(R.layout.activity_main, this);
	}

	public Command	StartCosmicDataActivity	= new Command() {
												public void Invoke(View view, Object... args) {
													launchActivity(InputFieldsActivity.class);
												}
											};

	public Command	StartListViewActivity	= new Command() {
												public void Invoke(View view, Object... args) {
													launchActivity(ListViewActivity.class);
												}
											};

	private <T> void launchActivity(Class<T> clazz) {
		Intent intent = new Intent(this, clazz);
		startActivity(intent);
	}

}
