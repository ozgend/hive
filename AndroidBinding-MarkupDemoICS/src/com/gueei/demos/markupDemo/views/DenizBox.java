package com.gueei.demos.markupDemo.views;

import android.content.Context;
import android.util.AttributeSet;
import android.util.Log;
import android.widget.EditText;

public class DenizBox extends EditText {

	public DenizBox(Context context, AttributeSet attrs) {
		super(context, attrs);
	}

	
	public float	aValue	= 0f;
	
	getV

	@Override
	public void setText(CharSequence text, BufferType type) {
		super.setText(text, type);
	}

	@Override
	protected void onTextChanged(CharSequence text, int start, int lengthBefore, int lengthAfter) {
		try {
			this.aValue = Float.parseFloat(text.toString());
		} catch (Exception e) {
			Log.e("DenizBox", String.format("DenizBox Conversion Failed %s", text));
		}

		super.onTextChanged(text, start, lengthBefore, lengthAfter);
	}

}