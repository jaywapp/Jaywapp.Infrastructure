namespace Jaywapp.Infrastructure.Interfaces
{
/// <summary>
/// Block 인터페이스를 정의합니다.
/// </summary>
    public interface IBlock
    {
        /// <summary>
        /// 이미지 경로
        /// </summary>
        string Image { get; }
        /// <summary>
        /// 블록 이름
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 블록 설명
        /// </summary>
        string Description { get; }
    }
}
