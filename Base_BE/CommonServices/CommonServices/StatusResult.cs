
namespace CommonServices.CommonServices
{
    public static class StatusResult
    {
        #region Mã lỗi

        public const int LOGIN_SUCCESS_CODE = 1;
        public const string LOGIN_SUCCESS_MESS = "Đăng nhập thành công";

        public const int CREATE_SUCCESS_CODE = 2;
        public const string CREATE_SUCCESS_MESS = "Thêm mới bản ghi thành công";

        public const int EDIT_SUCCESS_CODE = 3;
        public const string EDIT_SUCCESS_MESS = "Sửa thông tin bản ghi thành công";

        public const int DELETE_SUCCESS_CODE = 4;
        public const string DELETE_SUCCESS_MESS = "Xóa bản ghi thành công";

        public const int GETDATA_SUCCESS_CODE = 5;
        public const string GETDATA_SUCCESS_MESS = "Tải dữ liệu thành công";

        public const int NOTFOUND_CODE = -1;
        public const string NOTFOUND_MESS = "Không tìm thấy bản ghi";

        public const int DUPPLICATE_USER_CODE = -2;
        public const string DUPPLICATE_USER_MESS = "Tên đăng nhập đã tồn tại";

        public const int DUPPLICATE_EMAIL_CODE = -3;
        public const string DUPPLICATE_EMAIL_MESS = "Email đã tồn tại";

        public const int DUPPLICATE_PHONE_CODE = -4;
        public const string DUPPLICATE_PHONE_MESS = "Số điện thoại đã tồn tại";

        public const int DUPPLICATE_STATEIDCARD_CODE = -5;
        public const string DUPPLICATE_STATEIDCARD_MESS = "Số căn cước đã tồn tại";

        public const int SERVER_ERROR_CODE = -99;
        public const string SERVER_ERROR_MESS = "Lỗi server";

        public const int FAIL_CODE = -98;
        public const string FAIL_MESS = "Thất bại";
        #endregion
    }
}
