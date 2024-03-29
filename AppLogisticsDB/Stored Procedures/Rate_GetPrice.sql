﻿-- =============================================
-- Author:		Andrés Forero
-- Create date: 2017-04-27
-- Description:	Permite conocer el precio de una tarifa a partir del cliente, actividad y vehículo
-- =============================================
CREATE PROCEDURE [dbo].[Rate_GetPrice]
	-- Add the parameters for the stored procedure here
	@clientId INT,
	@activityId INT,
	@vehicleTypeId INT = NULL 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	[Price]
	FROM	Rate
	WHERE	ClientId = @clientId
	AND		ActivityId = @activityId
	AND		VehicleTypeId = @vehicleTypeId

END