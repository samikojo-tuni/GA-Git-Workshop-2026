# Git Workshop (Godot + C#)

**Audience:** Games Academy season 2 students, artists and programmers  
**Focus:** branching and merging (no pull requests)  
**Engine:** Godot (text-based scenes), Language: C#  

## Prerequisites
- Git installed
- Godot 4.x installed
- VS Code + C# Dev Kit (optional but helpful)
- Clone this repo locally

## Workshop Flow (75–100 min)
1) Warm-up: Branch + commit basics (10–15m)
2) Parallel work (no conflict): art + code on separate files (15–20m)
3) Text conflict (C#): resolve by combining changes (20–25m)
4) Scene conflict (.tscn): resolve by picking the right property values (20–25m)
5) Asset conflict (SVG): resolve ours/theirs (10–15m)

Each exercise below includes exact commands. Suggested groups: 1-2 artists + 1 programmer.

---

## Preparation
Fork the workshop repository to your own GitHub (one member of the team). Share your copy to the rest of the team.

### Make Visual Studio Code your default merge tool
Git needs to know which tool should be used as merge tool and how to use it. Follow the instructions below to configure Visual Studio Code your default merge tool.

1) `git config --global merge.tool vscode`
2) `git config --global mergetool.vscode.cmd 'code --wait --merge $REMOTE $LOCAL $BASE $MERGED'`
3) `git config --global diff.tool vscode`
4) `git config --global difftool.vscode.cmd 'code --wait --diff $LOCAL $REMOTE'`

** NOTE! **  
Exercises should be done in the the order defined here. Previous changes should **NOT** be discarded between exercises.

## Exercise 1: Branch, change, merge (fast-forward)
Goal: create a branch, make a small change, merge back.

- Create branch and switch:
```bash
git checkout -b exercise1
```
- In Godot, open `Scenes/SpriteExample.tscn` and add a new `Label` node as child of the root `Node2D` (any text).
- Save, then commit:
```bash
git add Scenes/SpriteExample.tscn
git commit -m "Exercise 1: add label to the scene"
```
- Merge back to main (fast-forward expected):
```bash
git checkout main
git merge exercise1
```
- Delete your feature branch (optional):
```bash
git branch -d exercise1
```

Outcome: everyone completes a simple branch/merge cycle.

---

## Exercise 2: Parallel changes without conflict (code and scene)
Goal: experience merging two branches that edit different files.

Prepared branches (already created by instructor):
- `feature/rotate-sprite` (code): rotates sprite over time in `Code/Icon.cs`.
- `level/center-icon` (scene): moves sprite position in `Scenes/SpriteExample.tscn`.

Steps:
```bash
git checkout main
# Merge code first
git merge feature/rotate-sprite
# Then merge level branch
git merge level/center-icon
```

- Open the scene in Godot and run. You should see the sprite rotating and in a new position.
- Note there’s no conflict because files differ.

---

## Exercise 3: Intentional C# text conflict
Goal: resolve a merge conflict in the same method body.

Prepared branches:
- `feature/move-icon` modifies `_Process()` to move sprite horizontally.

Steps:
```bash
git checkout main
# Merge the branch to main; expect conflict in Code/Icon.cs
git merge feature/move-icon
```
Resolve:
```bash
git mergetool
```
Follow Visual Studio Code's instructions.

Commit your changes:
```bash
git add Code/Icon.cs
git commit -m "Resolve C# conflict by combining move + rotate"
```

Run in Godot and verify both effects are present.

---

## Exercise 4: Scene (.tscn) conflict
Goal: resolve a conflict in Godot scene text.

Prepared branches:
- merge in exercise 3 changed the `Icon`'s position.
- `level/bottom-right` sets `Icon` position to other value.

Steps:
```bash
git checkout main
git merge level/bottom-right
# There should now be a merge conflict.
```
Resolve:
- run `git mergetool` and decide on final `position = Vector2(x, y)` for `Icon`.
- Save, stage, and commit.

Tip: It’s safe to edit .tscn in VS Code as it’s plain text, but verify in Godot by reopening the scene.

---

## Exercise 5: Asset (SVG) conflict
Goal: resolve a conflict when two branches replace the same asset.

Prepared branches:
- `art/icon-red` replaces `icon.svg` with a red icon.
- `art/icon-blue` replaces `icon.svg` with a blue icon.

Steps:
```bash
git checkout main
git merge art/icon-red
# Now merge the other branch and resolve
git merge art/icon-blue
```
Resolve:
- Choose either version (ours/theirs) or bring in a new asset and re-commit.
```bash
# Example: keep current (ours) for icon.svg
git checkout --ours icon.svg
git add icon.svg
git commit -m "Resolve icon.svg conflict by keeping ours"
```

Optional note: For large PNGs, consider Git LFS. SVGs are text and mergeable but still can conflict.
