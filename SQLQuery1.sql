create proc sp_DeleteSinhVien
@MaSV nvarchar(50)
as
Delete from SinhVien
where MaSV = @MaSV
