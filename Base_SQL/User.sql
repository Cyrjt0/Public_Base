CREATE TABLE Users (
    UserId UNIQUEIDENTIFIER PRIMARY KEY,  	-- ID duy nhất của mỗi người dùng
	UsersAccount NVARCHAR(100) NOT NULL,  	-- Tài khoản đăng nhập
	UsersPassword NVARCHAR(100) NOT NULL, 	-- Tài khoản đăng nhập ( SHA265 crypt )
    FullName NVARCHAR(200) NOT NULL,        -- Họ và tên đầy đủ của người dùng
    Address NVARCHAR(200) NOT NULL,         -- Họ và tên đầy đủ của người dùng
    PhoneNumber NVARCHAR(200) NOT NULL,     -- Họ và tên đầy đủ của người dùng
    StateIDCard NVARCHAR(200) NOT NULL,     -- Căn cước công dân
    Email NVARCHAR(200) NOT NULL,           -- Email của người dùng
    IsLock BIT ,                  			-- Trạng thái khóa ( sai pass 5 lần block 5 phút ) (0 - không khóa, 1 - bị khóa)
    IsBlock BIT ,                			-- Khóa khỏi hệ thống (0 - không khóa, 1 - bị khóa)
    IsActive BIT,                			-- Trạng thái kích hoạt của người dùng (0 - chưa active, 1 - đã active)
	StatusLogin int NOT NULL default 0		-- CheckLogin lần thứ bao nhiêu
);