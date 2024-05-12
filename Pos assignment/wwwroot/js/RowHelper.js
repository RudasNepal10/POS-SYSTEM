var RowHelper = function() {
		var prefix = "item-";
		if(RowHelper.instance == null) {
			RowHelper.instance = this;
		}
		else {
			RowHelper.instance;
		}
		
		this.constructRowIdOf = function(id) {
			return prefix + id;
		};

		
		this.getStockItemSelectElementInRow = function($targetRow) {
			return $targetRow.find(".stock-item");
		};


		this.getCaseUnitQtyElementInRow = function($targetRow) {
			return $targetRow.find(".main_unit_quantity");
		};

		this.getCaseUnitRateElementInRow = function($targetRow) {
			return $targetRow.find(".main_unit_rate");
		};

		this.getPcsUnitQtyElementInRow = function($targetRow) {
			return $targetRow.find(".sub_unit_quantity");
		};

		this.getPcsUnitRateElementInRow = function($targetRow) {
			return $targetRow.find(".sub_unit_rate");
		};

		this.getAmountBeforeDiscountElement = function($targetRow) {
			return $targetRow.find(".amount_before_discount");
		};

		this.getDiscountElement = function($targetRow) {
			return $targetRow.find(".discount");
		};

		this.getAmountAfterDiscountElement = function($targetRow) {
			return $targetRow.find(".amount");
		};

		
		
	};

	