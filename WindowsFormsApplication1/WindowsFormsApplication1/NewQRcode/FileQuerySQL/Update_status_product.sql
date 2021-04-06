
DECLARE	@return_value int
EXEC  @return_value= [dbo].[UpdatePOStatus]
      @PO          = '$VALUE_PO_NUMBER'




