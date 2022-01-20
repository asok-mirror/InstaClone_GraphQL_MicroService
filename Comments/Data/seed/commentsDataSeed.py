from typing import List
from Data.entities.comments import Comment


def Seed_comments() -> List[Comment]:
    comments = []

    comments.append(Comment(101, 1001, 1, "This is a comment 1"))
    comments.append(Comment(102, 1001, 1, "This is a comment 2"))
    comments.append(Comment(103, 1002, 3, "This is a comment 3"))
    comments.append(Comment(104, 1003, 3, "This is a comment 4"))
    comments.append(Comment(105, 1004, 4, "This is a comment 5"))
    comments.append(Comment(106, 1005, 5, "This is a comment 6"))

    return comments
