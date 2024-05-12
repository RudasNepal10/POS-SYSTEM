var Row = function($row_id,$element_name_prefix) {
		
		var rowHelper = new RowHelper();

		var id = $row_id;

		var element_name_prefix = $element_name_prefix;
		
		var rowId = rowHelper.constructRowIdOf(id);
		var targetRow = $("#" + rowId);

		var caseUnitQtyElement  = rowHelper.getCaseUnitQtyElementInRow(targetRow);
		var caseUnitRateElement = rowHelper.getCaseUnitRateElementInRow(targetRow);
		
		var pcsUnitQtyElement = rowHelper.getPcsUnitQtyElementInRow(targetRow);
		var pcsUnitRateElement = rowHelper.getPcsUnitRateElementInRow(targetRow);
		
		var amountBeforeDiscountElement = rowHelper.getAmountBeforeDiscountElement(targetRow);

		var discountElement = rowHelper.getDiscountElement(targetRow);

		var amountAfterDiscountElement = rowHelper.getAmountAfterDiscountElement(targetRow);

		this.getElement = function() {
			return targetRow;
		};

		this.getCaseUnitQtyElement = function() {
			return caseUnitQtyElement;
		};

		this.getCaseUnitQty = function() {
			return caseUnitQtyElement.val();
		};
		this.setCaseUnitQty = function(caseUnitQty) {
			caseUnitQtyElement.val(caseUnitQty);
			return this;
		};
		
		this.getCaseUnitRateElement = function() {
			return caseUnitRateElement;
		};
		this.getCaseUnitRate = function() {
			return caseUnitRateElement.val();
		};

		this.getPcsUnitQtyElement = function() {
			return pcsUnitQtyElement;
		};
		this.getPcsUnitQty = function() {
			return pcsUnitQtyElement.val();
		};
		this.setPcsUnitQty = function(pcsUnitQty) {
			pcsUnitQtyElement.val(pcsUnitQty);
			return this;
		};

		this.getPcsUnitRateElement = function() {
			return pcsUnitRateElement;
		};
		this.getPcsUnitRate = function() {
			return pcsUnitRateElement.val();
		};

		this.getAmountBeforeDiscountElement = function() {
			return amountBeforeDiscountElement;
		};
		this.getAmountBeforeDiscount = function() {
			return amountBeforeDiscountElement.val();
		};

		this.getDiscountElement = function() {
			return discountElement;
		};
		this.getDiscount = function() {
			return discountElement.val();
		};
		var setDiscount = function(discount) {
			discountElement.val(discount);
			return this;
		};

		this.getAmountAfterDiscountElement = function() {
			return amountAfterDiscountElement;
		};
		this.getAmountAfterDiscount = function() {
			return amountAfterDiscountElement.val();
		};
		

		this.calculateAmount = function() {
			
			var amtBeforeDiscount = customParseFloat(this.calculateAmountBeforeDiscount());

			this.getAmountBeforeDiscountElement()
				.val(amtBeforeDiscount);
			
			var amtAfterDiscount  = customParseFloat(this.calculateAmountAfterDiscount());

			if( amtAfterDiscount < 0 ) {
				setDiscount(amtBeforeDiscount);
				new ToastMessage("Discount cannot be more than the actual amount. It has been reset to the highest possible value (the total amount) ");
			}

			this.getAmountAfterDiscountElement()
				.val(customParseFloat(amtBeforeDiscount));
		};

		this.calculateAmountBeforeDiscount = function() {
			var caseQty  = this.getCaseUnitQty();
			var caseRate = this.getCaseUnitRate();
			var pcsQty   = this.getPcsUnitQty();
			var pcsRate  = this.getPcsUnitRate();
			return (caseQty * caseRate) + (pcsQty * pcsRate);
		};

		this.calculateAmountAfterDiscount = function() {
			return this.calculateAmountBeforeDiscount() - this.getDiscount();
		};

		this.clone = function() {

			var rowIdOfOriginal = parseInt(targetRow.data('rowid'));

			var newRowId = rowIdOfOriginal + 1;

			var clonedRow = targetRow.clone();

			clonedRow = this.updateRow(clonedRow, newRowId);

			return clonedRow;

		};

		this.updateRow = function(row, newRowId) {

			row.attr('data-rowid', newRowId  );

			var actualRowId = (new RowHelper()).constructRowIdOf(newRowId);

			row.attr('id', actualRowId);

			row = updateSn(row, newRowId);

			row = updateIdentifier(row, newRowId);
			
			row = updateStockItemSelect(row, newRowId);

			row = updateCaseUnitQtyElm(row, newRowId);
			
			row = updateCaseUnitRateElm(row, newRowId);
			
			row = updatePcsUnitQtyElm(row, newRowId);
			
			row = updatePcsUnitRateElm(row, newRowId);
			
			row = updateAmountBeforeDiscountElm(row, newRowId);
			
			//row = updateDiscountElm(row, newRowId);
			
			//row = updateAmountAfterDiscountElm(row, newRowId);

			row = updateRemoveButtonElement(row, newRowId);

			return row;

		};

		this.remove = function() {
			targetRow.remove();
		};

		this.clean = function() {
			this.updateRow(targetRow, targetRow.data('rowid'));
		};

		var updateSn = function(row, newRowId) {
			row.find('.sn').text(newRowId);
			return row;
		};

		var updateIdentifier = function (row, newRowId) {
			var item = row.find('.identifier');
			item.val(newRowId);
			return row;
		};

		var updateStockItemSelect = function(row, newRowId) {
			
			row.find('.stock-item').attr(	{
				"name" : element_name_prefix+"[" + newRowId + "].stock_item_id",
				"data-rowid" : newRowId
			}).removeClass('select2-hidden-accessible').next('span').remove();
			
			row.find('.stock-item').select2({width: "100%"});
			return row;
		
		};

		var updateNameAndData = function (item, newRowId, namePostfix) {
			item.attr({
				"name": element_name_prefix + "[" + newRowId + "]." + namePostfix,
				"data-rowid" : newRowId
			});
			return item;
		};

		var updateCaseUnitQtyElm = function (row, newRowId) {
			var item = row.find('.main_unit_quantity');
			item = updateNameAndData(item, newRowId, 'main_unit_quantity');
			item.val(0);
			return row;
		};

		var updateCaseUnitRateElm = function(row, newRowId) {
			var item = row.find('.main_unit_rate');
			item = updateNameAndData(item, newRowId, 'main_unit_rate');
			item.val(0);
			return row;
		};

		var updatePcsUnitQtyElm = function(row, newRowId) {
			
			var item = row.find('.sub_unit_quantity');
			item = updateNameAndData(item, newRowId, 'sub_unit_quantity');
			item.val(0);
			return row;
		};

		var updatePcsUnitRateElm = function(row, newRowId) {
			var item = row.find('.sub_unit_rate');
			item = updateNameAndData(item, newRowId, 'sub_unit_rate');
			item.val(0);
			return row;
		};

		var updateAmountBeforeDiscountElm = function(row, newRowId) {
			var item = row.find('.amount');
			item = updateNameAndData(item, newRowId, 'amount');
			item.val(0);
			return row;
		};

		

		var updateAmountAfterDiscountElm = function(row, newRowId) {
			var item = row.find('.amount_after_discount');
			item = updateNameAndData(item, newRowId, 'amount_after_discount');
			item.val(0);
			return row;
		};

		var updateRemoveButtonElement = function(row, newRowId) {
			var item = row.find('.btn-remove');
			item = updateNameAndData(item, newRowId, 'btn-remove');
			//item.val(0);
			return row;
		};


	};